using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;
using Newtonsoft.Json;
using Rest.Model;


namespace Rest.Web
{ 
    [ApiController]
    public class DocumentTypesController : ControllerBase
    { 
        [HttpPost]
        [Route("/api/document_types")]
        [Consumes("application/json", "text/json", "application/*+json")]
        [SwaggerOperation("CreateDocumentType")]
        public virtual IActionResult CreateDocumentType([FromBody]NewDocumentType newDocumentType)
        {
            throw new NotImplementedException();
        }
        [HttpDelete]
        [Route("/api/document_types/{id}")]
        [SwaggerOperation("DeleteDocumentType")]
        public virtual IActionResult DeleteDocumentType([FromRoute (Name = "id")][Required]int id)
        {
            throw new NotImplementedException();
        }
        [HttpGet]
        [Route("/api/document_types")]
        [SwaggerOperation("GetDocumentTypes")]
        public virtual IActionResult GetDocumentTypes()
        {
            throw new NotImplementedException();
        }
        [HttpPut]
        [Route("/api/document_types/{id}")]
        [Consumes("application/json", "text/json", "application/*+json")]
        [SwaggerOperation("UpdateDocumentType")]
        public virtual IActionResult UpdateDocumentType([FromRoute (Name = "id")][Required]int id, [FromBody]DocumentType documentType)
        {
            throw new NotImplementedException();
        }
    }
}