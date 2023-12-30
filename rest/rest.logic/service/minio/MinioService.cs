using Microsoft.Extensions.Configuration;
using Minio;
using Minio.DataModel.Args;

namespace Rest.Logic.Service {
    public class MinioService : IMinioService {
        private static readonly BucketExistsArgs BUCKET_EXISTS = new BucketExistsArgs().WithBucket("paperless");
        private static readonly MakeBucketArgs BUCKET_CREATE = new MakeBucketArgs().WithBucket("paperless");
        private readonly MinioClient minioClient;

        private static readonly IConfiguration CONFIG = new ConfigurationBuilder()
            .AddJsonFile("appsettings.json", false, true)
            .Build();

        public MinioService() {
            minioClient = (MinioClient)new MinioClient().WithEndpoint(CONFIG.GetChildren).WithCredentials(accessKey, secretKey);
        }


        public async Task AddDocument(long documentId, string filePath) {
            try {
                // Ensure that the bucket exists, create it if not
                bool bucketExists = minioClient.BucketExistsAsync(BUCKET_EXISTS).GetAwaiter().GetResult();
                
                if (!bucketExists) {
                    minioClient.MakeBucketAsync(BUCKET_CREATE).GetAwaiter().GetResult();
                }

                // Build the file from filepath to a stream
                FileStream fs = File.Open(filePath, FileMode.Open);

                // Upload the document to Minio
                // TODO: Change filename to real filename instead of placeholder
                PutObjectArgs OBJECT_ARGS = new PutObjectArgs().WithFileName("test.pdf").WithStreamData(fs);
                await minioClient.PutObjectAsync(OBJECT_ARGS);

                // If you've reached here, the document has been successfully added to Minio
                Console.WriteLine($"Document with ID {documentId} added to Minio bucket.");
            } catch (Exception ex) {
                // Handle exceptions appropriately (logging, throwing, etc.)
                Console.WriteLine($"Error adding document with ID {documentId} to Minio: {ex.Message}");
            }
        }
    }
}
