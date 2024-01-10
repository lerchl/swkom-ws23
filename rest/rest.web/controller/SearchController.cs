using Microsoft.AspNetCore.Mvc;
using Rest.Logic.Service;

namespace Rest.Web.Controller
{ 
    [ApiController]
    public class SearchController : ControllerBase
    {
        private readonly IElasticSearchService _elasticSearchService;

        // /////////////////////////////////////////////////////////////////////////
        // Init
        // /////////////////////////////////////////////////////////////////////////

        public SearchController(IElasticSearchService elasticSearchService)
        {
            _elasticSearchService = elasticSearchService;
        }

        // /////////////////////////////////////////////////////////////////////////
        // Methoden
        // /////////////////////////////////////////////////////////////////////////

        [HttpGet]
        [Route("/api/search/autocomplete")]
        public async virtual Task<IActionResult> AutoComplete([FromQuery (Name = "term")]string term, [FromQuery (Name = "limit")]int? limit)
        {
            return Ok((await _elasticSearchService.SearchAsync("documents", term)).Select(d => d.Title));
        }
    }
}