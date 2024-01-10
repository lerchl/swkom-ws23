using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Nest;
using Microsoft.Extensions.Configuration;
using Rest.Model;

namespace Rest.Logic.Service;

public class ElasticSearchService : IElasticSearchService
{
    private static readonly IConfiguration CONFIG = new ConfigurationBuilder()
        .AddJsonFile("appsettings.json", false, true)
        .Build();

    private readonly ElasticClient _client;

    public ElasticSearchService()
    {
        var settings = new ConnectionSettings(new Uri(CONFIG.GetSection("ElasticSearch:Node").Value!))
            .ServerCertificateValidationCallback((o, certificate, chain, errors) => true)
            .DefaultIndex("default_index")
            .BasicAuthentication("elastic", "password");

        _client = new ElasticClient(settings);
    }

    public async Task<IEnumerable<Document>> SearchAsync(string indexName, string query)
    {
        var response = await _client.SearchAsync<Document>(s => s.Index(indexName).Query(q =>
                q.Match(m => m.Field(f => f.OcrText).Query(query))
                        || q.Match(m => m.Field(f => f.Title).Query(query))
        ));

        if (!response.IsValid)
        {
            // Handle the error.
            throw new Exception($"Search failed: {response.OriginalException.Message}");
        }

        return response.Documents;
    }
}
