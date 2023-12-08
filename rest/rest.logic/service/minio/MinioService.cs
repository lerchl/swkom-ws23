using Minio;

namespace Rest.Logic.Service {
    public class MinioService : IMinioService {
        private static readonly string BUCKET_NAME = "paperless";
        private readonly MinioClient minioClient;

        public MinioService(string endpoint, string accessKey, string secretKey) {
            minioClient = (MinioClient)new MinioClient().WithEndpoint(endpoint).WithCredentials(accessKey, secretKey);
        }

        public void AddDocument(long documentId, string filePath) {
            try {
                // Ensure that the bucket exists, create it if not
                bool bucketExists = minioClient.BucketExistsAsync(BUCKET_NAME).GetAwaiter().GetResult();
                
                if (!bucketExists) {
                    minioClient.MakeBucketAsync(BUCKET_NAME).GetAwaiter().GetResult();
                }

                // Upload the document to Minio
                minioClient.PutObjectAsync(BUCKET_NAME, documentId.ToString(), filePath, "application/octet-stream").GetAwaiter().GetResult();

                // If you've reached here, the document has been successfully added to Minio
                Console.WriteLine($"Document with ID {documentId} added to Minio bucket {BUCKET_NAME}");
            } catch (Exception ex) {
                // Handle exceptions appropriately (logging, throwing, etc.)
                Console.WriteLine($"Error adding document with ID {documentId} to Minio: {ex.Message}");
            }
        }
    }
}
