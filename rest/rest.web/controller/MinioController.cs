using Microsoft.AspNetCore.Mvc;
using Minio;
using Minio.DataModel.Args;

namespace Rest.Web.Controller;

public class MinioController : ControllerBase {
    private readonly IMinioClient minioClient;

    public MinioController(IMinioClient minioClient) {
        this.minioClient = minioClient;
    }

    [HttpGet]
    [ProducesResponseType(typeof(string), StatusCodes.Status200OK)]
    public async Task<IActionResult> GetUrl(string bucketID) {
        return Ok(await minioClient.PresignedGetObjectAsync(new PresignedGetObjectArgs()
                .WithBucket(bucketID))
            .ConfigureAwait(false));
    }
}