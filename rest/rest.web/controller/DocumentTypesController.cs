using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Rest.Logic.Service;
using Rest.Model;

namespace Rest.Web.Controller;

[ApiController]
public class DocumentTypesController : ControllerBase
{
    private readonly IDocumentTypeService _service;

    // /////////////////////////////////////////////////////////////////////////
    // Init
    // /////////////////////////////////////////////////////////////////////////

    public DocumentTypesController(IDocumentTypeService service)
    {
        _service = service;
    }

    // /////////////////////////////////////////////////////////////////////////
    // Methods
    // /////////////////////////////////////////////////////////////////////////

    [HttpPost]
    [Route("/api/document_types")]
    [Consumes("application/json", "text/json", "application/*+json")]
    public virtual IActionResult CreateDocumentType([FromBody] DocumentType documentType)
    {
        var newDocumentType = _service.Add(documentType);
        return Created("/api/document_types/" + newDocumentType.Id, newDocumentType);
    }

    [HttpDelete]
    [Route("/api/document_types/{id}")]
    public virtual IActionResult DeleteDocumentType([FromRoute(Name = "id")][Required] int id)
    {
        _service.Remove(id);
        return NoContent();
    }

    [HttpGet]
    [Route("/api/document_types")]
    public virtual IActionResult GetDocumentTypes()
    {
        return Ok(_service.GetAll());
    }

    [HttpPut]
    [Route("/api/document_types/{id}")]
    [Consumes("application/json", "text/json", "application/*+json")]
    public virtual IActionResult UpdateDocumentType([FromRoute(Name = "id")][Required] int id, [FromBody] DocumentType documentType)
    {
        documentType.Id = id;
        return Ok(_service.Update(documentType));
    }
}
