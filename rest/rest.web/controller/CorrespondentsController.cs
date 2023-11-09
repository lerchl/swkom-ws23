using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Rest.Logic.Service;
using Rest.Model;

namespace Rest.Web.Controller;

[ApiController]
[Route("/api/correspondents")]
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
    [Consumes("application/json", "text/json", "application/*+json")]
    public virtual IActionResult CreateCorrespondent([FromBody] Correspondent correspondent)
    {
        var newCorrespondent = _service.Add(correspondent);
        return Created("/api/correspondents/" + newCorrespondent.Id, newCorrespondent);
    }

    [HttpDelete]
    [Route("/{id}")]
    public virtual IActionResult DeleteCorrespondent([FromRoute(Name = "id")][Required] int id)
    {
        _service.Remove(id);
        return NoContent();
    }

    [HttpGet]
    public virtual IActionResult GetCorrespondents()
    {
        return Ok(_service.GetAll());
    }

    [HttpPut]
    [Route("/{id}")]
    [Consumes("application/json", "text/json", "application/*+json")]
    public virtual IActionResult UpdateCorrespondent([FromRoute(Name = "id")][Required] int id, [FromBody] Correspondent correspondent)
    {
        correspondent.Id = id;
        return Ok(_service.Update(correspondent));
    }
}
