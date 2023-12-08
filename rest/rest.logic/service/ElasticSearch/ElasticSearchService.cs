using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Nest;

namespace Rest.Logic.Service;

public class ElasticSearchService : IElasticSearchService
{
    private readonly ElasticClient _client;

    public ElasticSearchService(Uri esNode)
    {
        var settings = new ConnectionSettings(esNode)
            .DefaultIndex("default_index");

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


// public class ElasticSearchIndex : ISearchIndex
// {
//     private readonly Uri _uri;
//     private readonly ILogger<ElasticSearchIndex> _logger;

//     public ElasticSearchIndex(IConfiguration configuration, ILogger<ElasticSearchIndex> logger)
//     {
//         this._uri = new Uri(configuration.GetConnectionString("ElasticSearch") ?? "http://localhost:9200/");
//         this._logger = logger;
//     }
//     public void AddDocumentAsync(Document document)
//     {
//         var elasticClient = new ElasticsearchClient(_uri);

//         if (!elasticClient.Indices.Exists("documents").Exists)
//             elasticClient.Indices.Create("documents");

//         var indexResponse = elasticClient.Index(document, "documents");
//         if (!indexResponse.IsSuccess())
//         {
//             // Handle errors
//             _logger.LogError($"Failed to index document: {indexResponse.DebugInformation}\n{indexResponse.ElasticsearchServerError}");

//             throw new Exception($"Failed to index document: {indexResponse.DebugInformation}\n{indexResponse.ElasticsearchServerError}");
//         }


//     }

//     public IEnumerable<Document> SearchDocumentAsync(string searchTerm)
//     {
//         var elasticClient = new ElasticsearchClient(_uri);

//         var searchResponse = elasticClient.Search<Document>(s => s
//             .Index("documents")
//             .Query(q => q.QueryString(qs => qs.DefaultField(p => p.Content).Query($"*{searchTerm}*")))
//         );

//         return searchResponse.Documents;
//     }
// }

