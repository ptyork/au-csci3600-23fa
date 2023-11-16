namespace CSCI3600.Pages.Topics;

using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

using CSCI3600.Data;

public class IndexModel : PageModel
{
    // PUBLIC MODEL PROPERTIES
    public IEnumerable<Topic> AllTopics { get; set; } = default!;

    // PRIVATE MODEL ATTRIBUTES & CONSTRUCTOR
    private readonly ILogger<IndexModel> _logger;
    private readonly MyDataContext _context;
    public IndexModel(ILogger<IndexModel> logger, MyDataContext context)
    {
        _logger = logger;
        _context = context;
    }

    public async Task OnGetAsync()
    {
        // this.AllTopics = FauxDb.Topics.ToList();
        this.AllTopics = await _context.Topics.ToListAsync();
    }
}
