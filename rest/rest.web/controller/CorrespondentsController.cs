using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Rest.Logic.Service;
using Rest.Model;

namespace Rest.Web.Controller;

[ApiController]
public class CorrespondentsController : ControllerBase
{
    private readonly ICorrespondentService _service;

    // /////////////////////////////////////////////////////////////////////////
    // Init
    // /////////////////////////////////////////////////////////////////////////

    public CorrespondentsController(ICorrespondentService service)
    {
        _service = service;
    }

    // /////////////////////////////////////////////////////////////////////////
    // Methods
    // /////////////////////////////////////////////////////////////////////////

    [HttpPost]
    [Route("/api/correspondents")]
    [Consumes("application/json", "text/json", "application/*+json")]
    public virtual IActionResult CreateCorrespondent([FromBody] Correspondent correspondent)
    {
        throw new NotImplementedException();
    }

    [HttpDelete]
    [Route("/api/correspondents/{id}")]
    public virtual IActionResult DeleteCorrespondent([FromRoute(Name = "id")][Required] int id)
    {
        throw new NotImplementedException();
    }

    [HttpGet]
    [Route("/api/correspondents")]
    public virtual IActionResult GetCorrespondents()
    {
        return Ok(_service.GetAll());
    }

    [HttpPut]
    [Route("/api/correspondents/{id}")]
    [Consumes("application/json", "text/json", "application/*+json")]
    public virtual IActionResult UpdateCorrespondent([FromRoute(Name = "id")][Required] int id, [FromBody] Correspondent correspondent)
    {
        throw new NotImplementedException();
    }
}
