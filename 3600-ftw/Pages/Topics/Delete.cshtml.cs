namespace CSCI3600.Pages.Topics;

using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

using CSCI3600.Data;

public class DeleteModel : PageModel
{
    [BindProperty]
    public Topic Topic { get; set; }

    // PRIVATE MODEL ATTRIBUTES & CONSTRUCTOR
    private readonly ILogger<DeleteModel> _logger;
    private readonly MyDataContext _context;
    public DeleteModel(ILogger<DeleteModel> logger, MyDataContext context)
    {
        _logger = logger;
        _context = context;
        this.Topic = new Topic();
    }

    public async Task<IActionResult> OnGetAsync(Guid? id)
    {
        if (id.HasValue)
        {
            // this.Topic = FauxDb.Topics
            //                    .Where(t => t.Id == id)
            //                    .Single();
            this.Topic = await _context.Topics
                                       .Where(t => t.Id == id)
                                       .SingleAsync();
            return Page();
        }
        else
        {
            return NotFound();
        }

    }

    public async Task<IActionResult> OnPostAsync()
    {
        // FauxDb.Delete(this.Topic);
        _context.Topics.Remove(this.Topic);
        await _context.SaveChangesAsync();
        
        return Redirect($"~/Topics");
    }
}

