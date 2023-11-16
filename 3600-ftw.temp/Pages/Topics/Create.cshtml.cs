namespace CSCI3600.Pages.Topics;

using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

using CSCI3600.Models;

public class CreateModel : PageModel
{
    [BindProperty]
    public Topic Topic { get; set; }

    // PRIVATE MODEL ATTRIBUTES & CONSTRUCTOR
    private readonly ILogger<CreateModel> _logger;
    public CreateModel(ILogger<CreateModel> logger)
    {
        _logger = logger;
        this.Topic = new Topic();
    }

    public IActionResult OnGet(Guid? id)
    {
        return Page();
    }

    public IActionResult OnPost()
    {
        var duplicate = FauxDb.Topics
                              .Where(t => t.Title == this.Topic.Title)
                              .Any();
        if (duplicate)
        {
            ModelState.AddModelError("Topic.Title", "Title must be unique");
        }
        if (!ModelState.IsValid)
        {
            return Page();
        }

        FauxDb.Add(this.Topic);
        
        return RedirectToPage("./Index");
    }
}

