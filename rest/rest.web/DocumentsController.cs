using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;
using Newtonsoft.Json;
using Rest.Model;

namespace Rest.Web
{ 
    [ApiController]
    public class DocumentsController : ControllerBase
    { 
        [HttpDelete]
        [Route("/api/documents/{id}")]
        [SwaggerOperation("DeleteDocument")]
        public virtual IActionResult DeleteDocument([FromRoute (Name = "id")][Required]int id)
        {
            throw new NotImplementedException();
        }
        [HttpGet]
        [Route("/api/documents/{id}/download")]
        [SwaggerOperation("DownloadDocument")]
        public virtual IActionResult DownloadDocument([FromRoute (Name = "id")][Required]int id, [FromQuery (Name = "original")]bool? original)
        {
            throw new NotImplementedException();
        }
        [HttpGet]
        [Route("/api/documents/{id}/metadata")]
        [SwaggerOperation("GetDocumentMetadata")]
        public virtual IActionResult GetDocumentMetadata([FromRoute (Name = "id")][Required]int id)
        {
            throw new NotImplementedException();
        }
        [HttpGet]
        [Route("/api/documents/{id}/preview")]
        [SwaggerOperation("GetDocumentPreview")]
        public virtual IActionResult GetDocumentPreview([FromRoute (Name = "id")][Required]int id)
        {
            throw new NotImplementedException();
        }
        [HttpGet]
        [Route("/api/documents/{id}/thumb")]
        [SwaggerOperation("GetDocumentThumb")]
        public virtual IActionResult GetDocumentThumb([FromRoute (Name = "id")][Required]int id)
        {
            throw new NotImplementedException();
        }
        [HttpGet]
        [Route("/api/documents")]
        [SwaggerOperation("GetDocuments")]
        public virtual IActionResult GetDocuments([FromQuery (Name = "Page")]int? page, [FromQuery (Name = "page_size")]int? pageSize, [FromQuery (Name = "query")]string query, [FromQuery (Name = "ordering")]string ordering, [FromQuery (Name = "tags__id__all")]List<int> tagsIdAll, [FromQuery (Name = "document_type__id")]int? documentTypeId, [FromQuery (Name = "correspondent__id")]int? correspondentId, [FromQuery (Name = "truncate_content")]bool? truncateContent)
        {
            throw new NotImplementedException();
        }
        [HttpPut]
        [Route("/api/documents/{id}")]
        [Consumes("application/json", "text/json", "application/*+json")]
        [SwaggerOperation("UpdateDocument")]
        public virtual IActionResult UpdateDocument([FromRoute (Name = "id")][Required]int id, [FromBody]Document document)
        {
            throw new NotImplementedException();
        }
        [HttpPost]
        [Route("/api/documents/post_document")]
        [Consumes("multipart/form-data")]
        [SwaggerOperation("UploadDocument")]
        public virtual IActionResult UploadDocument([FromForm (Name = "title")]string title, [FromForm (Name = "created")]DateTime? created, [FromForm (Name = "document_type")]int? documentType, [FromForm (Name = "tags")]List<int> tags, [FromForm (Name = "correspondent")]int? correspondent, [FromForm (Name = "document")]List<System.IO.Stream> document)
        {
            throw new NotImplementedException();
        }
    }
}