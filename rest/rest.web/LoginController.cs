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
        public virtual IActionResult ApiGet()
        {
            throw new NotImplementedException();
        }

        [HttpPost]
        [Route("/api/token")]
        [Consumes("application/json", "text/json", "application/*+json")]
        public virtual IActionResult GetToken([FromBody]UserInfo userInfo)
        {
            throw new NotImplementedException();
        }

        [HttpPost]
        [Route("/api")]
        public virtual IActionResult Root()
        {
            throw new NotImplementedException();
        }

        [HttpGet]
        [Route("/api/statistics")]
        public virtual IActionResult Statistics()
        {
            throw new NotImplementedException();
        }
    }
}