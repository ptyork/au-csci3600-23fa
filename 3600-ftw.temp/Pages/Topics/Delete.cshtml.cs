namespace CSCI3600.Pages.Topics;

using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

using CSCI3600.Models;

public class DeleteModel : PageModel
{
    [BindProperty]
    public Topic Topic { get; set; }

    // PRIVATE MODEL ATTRIBUTES & CONSTRUCTOR
    private readonly ILogger<DeleteModel> _logger;
    public DeleteModel(ILogger<DeleteModel> logger)
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
            return NotFound();
        }

    }

    public IActionResult OnPost()
    {
        FauxDb.Delete(this.Topic);
        
        return Redirect($"~/Topics");
    }
}

