namespace CSCI3600.Pages.Topics;

using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

using CSCI3600.Models;

public class DetailsModel : PageModel
{
    public Topic Topic { get; set; }

    // PRIVATE MODEL ATTRIBUTES & CONSTRUCTOR
    private readonly ILogger<DetailsModel> _logger;
    public DetailsModel(ILogger<DetailsModel> logger)
    {
        _logger = logger;
        this.Topic = new Topic();
    }

    public IActionResult OnGet(Guid? id)
    {
        if (id.HasValue)
        {
            this.Topic = FauxDb.Topics
                               .Where(t => t.Id == id)
                               .Single();
            return Page();
        }
        else
        {
            // return StatusCode(StatusCodes.Status400BadRequest);
            return NotFound();
        }

    }

}