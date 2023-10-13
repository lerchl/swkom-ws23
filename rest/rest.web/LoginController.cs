using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;
using Rest.Model;

namespace Rest.Web
{ 
    [ApiController]
    public class LoginController : ControllerBase
    { 
        [HttpGet]
        [Route("/api")]
        [SwaggerOperation("ApiGet")]
        public virtual IActionResult ApiGet()
        {
            throw new NotImplementedException();
        }
        [HttpPost]
        [Route("/api/token")]
        [Consumes("application/json", "text/json", "application/*+json")]
        [SwaggerOperation("GetToken")]
        public virtual IActionResult GetToken([FromBody]UserInfo userInfo)
        {
            throw new NotImplementedException();
        }
        [HttpPost]
        [Route("/api")]
        [SwaggerOperation("Root")]
        public virtual IActionResult Root()
        {
            throw new NotImplementedException();
        }
        [HttpGet]
        [Route("/api/statistics")]
        [SwaggerOperation("Statistics")]
        public virtual IActionResult Statistics()
        {
            throw new NotImplementedException();
        }
    }
}