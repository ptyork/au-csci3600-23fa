namespace CSCI3600.Pages.Topics;

using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using CSCI3600.Models;

public class IndexModel : PageModel
{
    // PUBLIC MODEL PROPERTIES
    public IEnumerable<Topic> AllTopics { get; set; }

    // PRIVATE MODEL ATTRIBUTES & CONSTRUCTOR
    private readonly ILogger<IndexModel> _logger;
    public IndexModel(ILogger<IndexModel> logger)
    {
        _logger = logger;
        this.AllTopics = FauxDb.Topics;
    }

    public void OnGet()
    {
    }
}
