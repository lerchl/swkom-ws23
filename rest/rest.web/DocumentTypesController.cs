using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc;
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
        public virtual IActionResult CreateDocumentType([FromBody]DocumentType documentType)
        {
            throw new NotImplementedException();
        }

        [HttpDelete]
        [Route("/api/document_types/{id}")]
        public virtual IActionResult DeleteDocumentType([FromRoute (Name = "id")][Required]int id)
        {
            throw new NotImplementedException();
        }

        [HttpGet]
        [Route("/api/document_types")]
        public virtual IActionResult GetDocumentTypes()
        {
            throw new NotImplementedException();
        }

        [HttpPut]
        [Route("/api/document_types/{id}")]
        [Consumes("application/json", "text/json", "application/*+json")]
        public virtual IActionResult UpdateDocumentType([FromRoute (Name = "id")][Required]int id, [FromBody]DocumentType documentType)
        {
            throw new NotImplementedException();
        }
    }
}