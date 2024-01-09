namespace Rest.Logic.Service;
public interface IElasticSearchIndexService
{
    Task IndexDocumentAsync<T>(string indexName, T document) where T : class;
    
}