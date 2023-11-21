namespace CSCI3600.Pages.Topics;

using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

using CSCI3600.Data;

public class EditModel : PageModel
{
    [BindProperty]
    public Topic Topic { get; set; }

    // PRIVATE MODEL ATTRIBUTES & CONSTRUCTOR
    private readonly ILogger<EditModel> _logger;
    private readonly MyDataContext _context;
    public EditModel(ILogger<EditModel> logger, MyDataContext context)
    {
        _logger = logger;
        _context = context;
        this.Topic = new Topic();
    }

    public async Task<IActionResult> OnGetAsync(Guid? id)
    {
        // The request should contains an id.
        // Populate  then populate the
        // Model.RequestedTopic with the appropriate value.
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
        // var duplicate = FauxDb.Topics
        //                       .Where(t => t.Title == this.Topic.Title)
        //                       .Where(t => t.Id != this.Topic.Id)
        //                       .Any();
        var duplicate = await _context.Topics
                                      .Where(t => t.Title == this.Topic.Title)
                                      .Where(t => t.Id != this.Topic.Id)
                                      .AnyAsync();
        if (duplicate)
        {
            ModelState.AddModelError("Topic.Title", "Title must be unique");
        }
        if (!ModelState.IsValid)
        {
            return Page();
        }

        // FauxDb.Update(this.Topic);
        _context.Attach(this.Topic).State = EntityState.Modified;
        await _context.SaveChangesAsync();
        
        return Redirect($"~/Topics/Details/{Topic.Id}");
    }
}

