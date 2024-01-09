namespace Rest.Logic.Service;
public interface IMinioService {
    Task AddDocument(long documentId, Stream fileStream);
}
