using System.Text.Json;
using Microsoft.AspNetCore.Mvc;
using Rest.Web.Interfaces;
using Rest.Web.Model;

namespace Rest.Web.Controller;

[ApiController]
[Route("/api/saved_views/")]
public partial class SavedViewsController : ControllerBase
{
    // Assuming you have a service or database context for retrieving saved views
    private readonly ISavedViewsService _savedViewsService; // Example service for fetching saved views

    public SavedViewsController(ISavedViewsService savedViewsService)
    {
        _savedViewsService = savedViewsService;
    }

    [HttpGet(Name = "GetSavedViews")]
    public IActionResult GetSavedViews()
    {
        try
        {
            var allSavedViews = _savedViewsService.GetAllSavedViews(); // Retrieves all saved views

            return Ok(new ViewsListResponse()
            {
                Next = null, // You might want to implement pagination if the list is large
                Previous = null,
                Count = allSavedViews.Count,
                All = allSavedViews.Select(sv => (int)sv.Id).ToArray(), // Assuming each SavedView has an Id property
                Results = allSavedViews
            });
        }
        catch (Exception ex)
        {
            // Implement appropriate error handling. Log the exception and return an error response.
            return StatusCode(500, "An error occurred while processing your request.");
        }
    }
}
