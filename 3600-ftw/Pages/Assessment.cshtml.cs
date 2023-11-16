namespace CSCI3600.Pages;

using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

using CSCI3600.Data;

public class AssessmentModel : PageModel
{
    // PUBLIC MODEL PROPERTIES
    public IEnumerable<GradeCategory> GradeCategories { get; set; } = default!;

    // PRIVATE MODEL ATTRIBUTES & CONSTRUCTOR
    private readonly ILogger<AssessmentModel> _logger;
    private readonly MyDataContext _context;
    public AssessmentModel(ILogger<AssessmentModel> logger, MyDataContext context)
    {
        _logger = logger;
        _context = context;
    }

    public async Task OnGetAsync()
    {
        this.GradeCategories = await _context.GradeCategories
                                             .Include(gc => gc.GradeItems)
                                             .ToListAsync();
    }
}
