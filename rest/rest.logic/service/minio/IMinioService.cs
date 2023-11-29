using Minio;

namespace Rest.Logic.Service.Minio;
public interface IMinioService<E> where E : Entity {
    /// <summary>
    ///     Upload a file
    /// </summary>
    /// <returns>Task</returns>
    public Task UploadFileAsync(string bucketName, string objectName, string filePath, string contentType = "application/octet-stream");
}
