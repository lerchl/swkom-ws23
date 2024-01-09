using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Nest;
using Microsoft.Extensions.Configuration;

namespace Service;

public class ElasticSearchIndexService
{
    private static readonly IConfiguration CONFIG = new ConfigurationBuilder()
        .AddJsonFile("appsettings.json", false, true)
        .Build();

    private readonly ElasticClient _client;

    public ElasticSearchIndexService()
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
}