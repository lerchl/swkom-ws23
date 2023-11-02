using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Rest.Model;

namespace Rest.Web.Controller
{
    [ApiController]
    public class CorrespondentsController : ControllerBase
    { 
        [HttpPost]
        [Route("/api/correspondents")]
        [Consumes("application/json", "text/json", "application/*+json")]
        public virtual IActionResult CreateCorrespondent([FromBody]Correspondent correspondent)
        {
            throw new NotImplementedException();
        }

        [HttpDelete]
        [Route("/api/correspondents/{id}")]
        public virtual IActionResult DeleteCorrespondent([FromRoute (Name = "id")][Required]int id)
        {
            throw new NotImplementedException();
        }

        [HttpGet]
        [Route("/api/correspondents")]
        public virtual IActionResult GetCorrespondents()
        {
            throw new NotImplementedException();
        }

        [HttpPut]
        [Route("/api/correspondents/{id}")]
        [Consumes("application/json", "text/json", "application/*+json")]
        public virtual IActionResult UpdateCorrespondent([FromRoute (Name = "id")][Required]int id, [FromBody]Correspondent correspondent)
        {
            throw new NotImplementedException();
        }
    }
}