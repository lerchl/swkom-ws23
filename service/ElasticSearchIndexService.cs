using Elasticsearch.Net;
using Microsoft.Extensions.Configuration;
using Nest;

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
            .DefaultIndex("documents")
            .BasicAuthentication("elastic", "password");

        _client = new ElasticClient(settings);
    }

    public async Task IndexDocumentAsync<T>(Document document) where T : class
    {
        var response = await _client.IndexAsync(document, idx => idx.Index("documents").Id(document.Id).Refresh(Refresh.WaitFor));

        if (!response.IsValid)
        {
            // Handle the error
            throw new Exception($"Failed to index document: {response.OriginalException.Message}");
        }
    }
}
