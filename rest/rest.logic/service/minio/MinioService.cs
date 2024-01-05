using Microsoft.Extensions.Configuration;
using Minio;
using Minio.DataModel;
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
            var minio_endpoint = CONFIG.GetSection("Minio").GetSection("endpoint").Value;
            var minio_accesskey = CONFIG.GetSection("Minio").GetSection("accesskey").Value;
            var minio_secretkey = CONFIG.GetSection("Minio").GetSection("secretkey").Value;
            Console.WriteLine($"Minio endpoint: {minio_endpoint}");
            Console.WriteLine($"Minio accesskey: {minio_accesskey}");
            Console.WriteLine($"Minio secretkey: {minio_secretkey}");
            minioClient = (MinioClient)new MinioClient().WithEndpoint(minio_endpoint).WithCredentials(minio_accesskey, minio_secretkey);
        }


        public async Task AddDocument(long documentId, string filePath) {
            try {
                // Ensure that the bucket exists, create it if not
                var list = await minioClient.ListBucketsAsync();
                
                foreach (Bucket bucket in list.Buckets) {
                    Console.WriteLine(bucket.Name + " " + bucket.CreationDateDateTime);
                }

                bool bucketExists = await minioClient.BucketExistsAsync(BUCKET_EXISTS);
                
                if (!bucketExists) {
                    await minioClient.MakeBucketAsync(BUCKET_CREATE);
                }

                // Build the file from filepath to a stream
                FileStream fs = File.Open(filePath, FileMode.Open);

                // Upload the document to Minio
                PutObjectArgs OBJECT_ARGS = new PutObjectArgs().WithFileName(Path.GetFileName(filePath)).WithStreamData(fs);
                await minioClient.PutObjectAsync(OBJECT_ARGS);
                
                Console.WriteLine($"Document with ID {documentId} added to Minio bucket.");
            } catch (Exception ex) {
                // Handle exceptions appropriately (logging, throwing, etc.)
                Console.WriteLine($"Error adding document with ID {documentId} to Minio: {ex.Message}");
            }
        }
    }
}
