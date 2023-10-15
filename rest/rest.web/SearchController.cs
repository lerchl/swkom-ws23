using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

namespace Rest.Web
{ 
    [ApiController]
    public class SearchController : ControllerBase
    { 
        [HttpGet]
        [Route("/api/search/autocomplete")]
        public virtual IActionResult AutoComplete([FromQuery (Name = "term")]string term, [FromQuery (Name = "limit")]int? limit)
        {
            throw new NotImplementedException();
        }
    }
}