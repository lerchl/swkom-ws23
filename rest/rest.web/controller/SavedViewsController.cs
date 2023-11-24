using Microsoft.AspNetCore.Mvc;
using FizzWare.NBuilder;
using Rest.Logic.Service;
using Rest.Model;

namespace Rest.Web.Controller;


[ApiController]
[Route("/api/saved_views/")]
public partial class SavedViewsController : ControllerBase
{
    [HttpGet(Name = "GetSavedViews")]
    public IActionResult GetSavedViews()
    {
        int count = 1;
        return Ok(new ViewsListResponse()
        {
            Next = null,
            Previous = null,
            Count = count,
            All = Enumerable.Range(1, 3).ToArray(),
            Results = Builder<SavedView>.CreateListOfSize(count)
                        .All().With(p => p.Name = "Views")
                        .With(p => p.ShowInSidebar = true)
                        .With(p => p.ShowOnDashboard = true)
                        .With(p => p.FilterRules = new FilterRule[]{
                            new FilterRule(){
                                RuleType = 3,
                                Value="5"
                            }
                        })
                        .Build()
        });
    }
}
