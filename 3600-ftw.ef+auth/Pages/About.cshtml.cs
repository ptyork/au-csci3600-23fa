using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace CSCI3600.Pages
{
    public class AboutModel : PageModel
    {
        [FromQuery(Name = "s")]
        public string? SemesterName { get; set; }

        [FromQuery(Name = "i")]
        public string InstructorName { get; set; } = "TBA";


        private readonly ILogger<IndexModel> _logger;

        public AboutModel(ILogger<IndexModel> logger)
        {
            _logger = logger;
        }

        // DECORATION: additional info about how the environment
        // will process or retrieve some data.
        // public void OnGet([FromQuery(Name = "i")] string iName)
        public void OnGet()
        {
            // this.SemesterName = Request.Query["s"];
            // InstructorName = Request.Query["i"];
            // InstructorName = iName;
        }
    }
}
