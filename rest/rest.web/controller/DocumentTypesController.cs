using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Rest.Logic.Service;
using Rest.Model;


namespace Rest.Web.Controller;

[ApiController]
[Route("/api/document_types")]
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
    [Consumes("application/json", "text/json", "application/*+json")]
    public virtual IActionResult CreateDocumentType([FromBody] DocumentType documentType)
    {
        var newDocumentType = _service.Add(documentType);
        return Created("/api/tags/" + documentType.Id, documentType);
    }

    [HttpDelete]
    [Route("/{id}")]
    public virtual IActionResult DeleteDocumentType([FromRoute(Name = "id")][Required] int id)
    {
        throw new NotImplementedException();
    }

    [HttpGet]
    public virtual IActionResult GetDocumentTypes()
    {
        return Ok(_service.GetAll());
    }

    [HttpPut]
    [Route("/{id}")]
    [Consumes("application/json", "text/json", "application/*+json")]
    public virtual IActionResult UpdateDocumentType([FromRoute(Name = "id")][Required] int id, [FromBody] DocumentType documentType)
    {
        throw new NotImplementedException();
    }
}
