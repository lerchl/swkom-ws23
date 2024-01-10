using Rest.Model;

namespace Rest.Logic.Service;
public interface IElasticSearchService
{
    Task<IEnumerable<Document>> SearchAsync(string indexName, string query);
}