using Microsoft.Extensions.Configuration;
using Minio;
using Minio.DataModel.Args;

namespace Service;

class MinioService
{
    private readonly IMinioClient minioClient;

    private static readonly IConfiguration CONFIG = new ConfigurationBuilder()
        .AddJsonFile("appsettings.json", false, true)
        .Build();

    public MinioService()
    {
        var minio_endpoint = CONFIG.GetSection("Minio").GetSection("endpoint").Value;
        var minio_accesskey = CONFIG.GetSection("Minio").GetSection("accesskey").Value;
        var minio_secretkey = CONFIG.GetSection("Minio").GetSection("secretkey").Value;
        minioClient = new MinioClient().WithEndpoint(minio_endpoint).WithCredentials(minio_accesskey, minio_secretkey).Build();
    }

    public Task streamDocument(long documentId, Action<Stream> action)
    {
        var getObjectArgs = new GetObjectArgs().WithBucket("paperless").WithObject(documentId.ToString()).WithCallbackStream(action);
        return minioClient.GetObjectAsync(getObjectArgs);
    }
}

