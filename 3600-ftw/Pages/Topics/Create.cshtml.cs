namespace CSCI3600.Pages.Topics;

using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

using CSCI3600.Data;

public class CreateModel : PageModel
{
    [BindProperty]
    public Topic Topic { get; set; }

    // PRIVATE MODEL ATTRIBUTES & CONSTRUCTOR
    private readonly ILogger<CreateModel> _logger;
     private readonly MyDataContext _context;
    public CreateModel(ILogger<CreateModel> logger, MyDataContext context)
    {
        _logger = logger;
        _context = context;
        this.Topic = new Topic();
    }

    public void OnGet()
    {
    }

    public async Task<IActionResult> OnPostAsync()
    {
        // var duplicate = FauxDb.Topics
        //                       .Where(t => t.Title == this.Topic.Title)
        //                       .Any();
        var duplicate = await _context.Topics
                                      .Where(t => t.Title == this.Topic.Title)
                                      .AnyAsync();
        if (duplicate)
        {
            ModelState.AddModelError("Topic.Title", "Title must be unique");
        }
        if (!ModelState.IsValid)
        {
            return Page();
        }

        // FauxDb.Add(this.Topic);
        _context.Topics.Add(this.Topic);
        await _context.SaveChangesAsync();
        
        return RedirectToPage("./Index");
    }
}

