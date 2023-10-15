using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;
using Newtonsoft.Json;
using Rest.Model;

namespace Rest.Web
{ 
    [ApiController]
    public class TagsController : ControllerBase
    { 
        [HttpPost]
        [Route("/api/tags")]
        [Consumes("application/json", "text/json", "application/*+json")]
        public virtual IActionResult CreateTag([FromBody]DocTag docTag)
        {
            throw new NotImplementedException();
        }

        [HttpDelete]
        [Route("/api/tags/{id}")]
        public virtual IActionResult DeleteTag([FromRoute (Name = "id")][Required]int id)
        {
            throw new NotImplementedException();
        }

        [HttpGet]
        [Route("/api/tags")]
        public virtual IActionResult GetTags()
        {
            throw new NotImplementedException();
        }

        [HttpPut]
        [Route("/api/tags/{id}")]
        [Consumes("application/json", "text/json", "application/*+json")]
        public virtual IActionResult UpdateTag([FromRoute (Name = "id")][Required]int id, [FromBody]DocTag docTag)
        {
            throw new NotImplementedException();
        }
    }
}