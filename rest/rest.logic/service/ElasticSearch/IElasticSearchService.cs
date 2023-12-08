namespace Rest.Logic.Service;
public interface IElasticSearchService
{
    Task IndexDocumentAsync<T>(string indexName, T document) where T : class;
    Task<IEnumerable<T>> SearchAsync<T>(string indexName, string query) where T : class;
}