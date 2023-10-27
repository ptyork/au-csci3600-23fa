using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace CSCI3600.Pages
{
    public class ContactModel : PageModel
    {
        private readonly ILogger<ContactModel> _logger;

        public ContactModel(ILogger<ContactModel> logger)
        {
            _logger = logger;
        }

        private void debug(string text)
        {
            // _logger.LogInformation(text);
            // _logger.LogDebug(text);
            Console.WriteLine(text);
        }

        public void OnGet()
        {
            debug("PROCESSING GET REQUEST");
            debug("QUERY STRING VALUES");
            if (Request.Query.Any())
            {
                foreach (var key in Request.Query.Keys)
                {
                    var value = Request.Query[key];
                    debug($"{key} ==> {value}");
                }
            }
            else
            {
                debug("No Query Values");
            }
        }

        public void OnPost()
        {
            debug("PROCESSING POST REQUEST");
            debug("QUERY STRING VALUES");
            if (Request.Query.Any())
            {
                foreach (var key in Request.Query.Keys)
                {
                    var value = Request.Query[key];
                    debug($"{key} ==> {value}");
                }
            }
            else
            {
                debug("No Query Values");
            }

            debug("REQUEST BODY VALUES");
            if (Request.Form.Any())
            {
                foreach (var key in Request.Form.Keys)
                {
                    var value = Request.Form[key];
                    debug($"{key} ==> {value}");
                }
            }
            else
            {
                debug("No Body Values");
            }
        }
    }
}
