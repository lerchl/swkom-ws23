using Rest.Model;

namespace Rest.Logic.Service;
public interface IMinioService {
    void AddDocument(long documentId, string filePath);
}
