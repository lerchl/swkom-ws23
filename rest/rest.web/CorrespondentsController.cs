using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;
using Newtonsoft.Json;
using Rest.Model;

namespace Rest.Web
{ 
    [ApiController]
    public class CorrespondentsController : ControllerBase
    { 
        [HttpPost]
        [Route("/api/correspondents")]
        [Consumes("application/json", "text/json", "application/*+json")]
        [SwaggerOperation("CreateCorrespondent")]
        public virtual IActionResult CreateCorrespondent([FromBody]NewCorrespondent newCorrespondent)
        {
            throw new NotImplementedException();
        }
        [HttpDelete]
        [Route("/api/correspondents/{id}")]
        [SwaggerOperation("DeleteCorrespondent")]
        public virtual IActionResult DeleteCorrespondent([FromRoute (Name = "id")][Required]int id)
        {
            throw new NotImplementedException();
        }
        [HttpGet]
        [Route("/api/correspondents")]
        [SwaggerOperation("GetCorrespondents")]
        public virtual IActionResult GetCorrespondents()
        {
            throw new NotImplementedException();
        }
        [HttpPut]
        [Route("/api/correspondents/{id}")]
        [Consumes("application/json", "text/json", "application/*+json")]
        [SwaggerOperation("UpdateCorrespondent")]
        public virtual IActionResult UpdateCorrespondent([FromRoute (Name = "id")][Required]int id, [FromBody]Correspondent correspondent)
        {
            throw new NotImplementedException();
        }
    }
}