namespace CSCI3600.Pages.Topics;

using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

using CSCI3600.Data;

public class DetailsModel : PageModel
{
    public Topic Topic { get; set; }

    // PRIVATE MODEL ATTRIBUTES & CONSTRUCTOR
    private readonly ILogger<DetailsModel> _logger;
     private readonly MyDataContext _context;
   public DetailsModel(ILogger<DetailsModel> logger, MyDataContext context)
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
            // return StatusCode(StatusCodes.Status400BadRequest);
            // return StatusCode(StatusCodes.Status404NotFound);
            return NotFound();
        }

    }

}