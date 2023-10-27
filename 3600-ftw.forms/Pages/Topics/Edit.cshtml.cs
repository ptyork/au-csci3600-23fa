namespace CSCI3600.Pages.Topics;

using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

using CSCI3600.Models;

public class EditModel : PageModel
{
    [BindProperty]
    public Topic Topic { get; set; }

    // PRIVATE MODEL ATTRIBUTES & CONSTRUCTOR
    private readonly ILogger<EditModel> _logger;
    public EditModel(ILogger<EditModel> logger)
    {
        _logger = logger;
        this.Topic = new Topic();
    }

    public IActionResult OnGet(Guid? id)
    {
        // The request should contains an id.
        // Populate  then populate the
        // Model.RequestedTopic with the appropriate value.
        if (id.HasValue)
        {
            this.Topic = FauxDb.Topics
                               .Where(t => t.Id == id)
                               .Single();
            return Page();
        }
        else
        {
            return NotFound();
        }

    }

    public IActionResult OnPost()
    {
        if (!ModelState.IsValid)
        {
            return Page();
        }

        FauxDb.Update(this.Topic);
        
        // return RedirectToPage("./Details", new { id = this.Topic.Id });
        return Redirect($"~/Topics/Details/{Topic.Id}");
    }
}

