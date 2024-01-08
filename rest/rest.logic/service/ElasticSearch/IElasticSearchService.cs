namespace Rest.Logic.Service;
public interface IElasticSearchService
{
    Task<IEnumerable<T>> SearchAsync<T>(string indexName, string query) where T : class;
}