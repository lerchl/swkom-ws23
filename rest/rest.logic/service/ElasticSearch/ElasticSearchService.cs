using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Nest;
using Microsoft.Extensions.Configuration;

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

    public async Task IndexDocumentAsync<T>(string indexName, T document) where T : class
    {
        var response = await _client.IndexDocumentAsync(document);

        if (!response.IsValid)
        {
            // Handle the error.
            throw new Exception($"Failed to index document: {response.OriginalException.Message}");
        }
    }

    public async Task<IEnumerable<T>> SearchAsync<T>(string indexName, string query) where T : class
    {
        var response = await _client.SearchAsync<T>(s => s
            .Index(indexName)
            .Query(q => q
                .QueryString(d => d
                    .Query(query)
                )
            )
        );

        if (!response.IsValid)
        {
            // Handle the error.
            throw new Exception($"Search failed: {response.OriginalException.Message}");
        }

        return response.Documents;
    }
}
