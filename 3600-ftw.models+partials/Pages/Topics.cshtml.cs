using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using CSCI3600.Models;

namespace CSCI3600.Pages
{
    public class TopicsModel : PageModel
    {
        // FAKE DATABASE OF TOPICS
        private static List<Topic> _allTopics = new List<Topic>
        {
            new Topic{ Description="HTML5 Basics", Hours=6 },
            new Topic{ Description="HTML5 DOM and CSS3", Hours=6 },
            new Topic{ Description="CSS for Page Layout", Hours=6 },
            new Topic{ Description="The “Web Stack”", Hours=3 },
            new Topic{ Description="Web Development Architectural Alternatives", Hours=3 },
            new Topic{ Description="Server-Side Scripting Intro", Hours=6 },
            new Topic{ Description="ASP.NET Overview", Hours=3 },
            new Topic{ Description="ASP.NET Razor Pages Overview", Hours=6 },
            new Topic{ Description="HTTP Requests, Responses & Statelessness", Hours=3 },
            new Topic{ Description="ASP.NET Routing, Page Models & Partial Views", Hours=3 },
            new Topic{ Description=".NET Entity Framework Core", Hours=6 },
            new Topic{ Description="ASP.NET Data Driven Pages", Hours=6 },
            new Topic{ Description="ASP.NET Forms", Hours=3 },
            new Topic{ Description="ASP.NET Authentication & Authorization", Hours=3 },
            new Topic{ Description="ASP.NET State Management", Hours=3 },
            new Topic{ Description="JavaScript Language Basics", Hours=6 },
            new Topic{ Description="JavaScript and the DOM", Hours=3 },
            new Topic{ Description="JavaScript Objects & JSON", Hours=3 },
            new Topic{ Description="ASP.NET Web Services & RESTful Interfaces", Hours=3 },
            new Topic{ Description="Introduction to Modern JavaScript Frameworks", Hours=3 },
            new Topic{ Description="Web Application Security Concerns", Hours=3 }
        };

        // PUBLIC MODEL PROPERTIES
        public List<Topic> AllTopics { get; set; } = _allTopics;

        public Topic? RequestedTopic { get; set; }


        // PRIVATE MODEL ATTRIBUTES & CONSTRUCTOR
        private readonly ILogger<ErrorModel> _logger;
        public TopicsModel(ILogger<ErrorModel> logger)
        {
            _logger = logger;
        }

        public void OnGet(Guid? id)
        {
            // If the request contains an id, then populate the
            // Model.RequestedTopic with the appropriate value.
            if (id.HasValue)
            {
                try
                {
                    // Use "magic" to find the requested topic
                    RequestedTopic = 
                        AllTopics.First(t => t.Id == id.Value);
                }
                catch
                {
                    // ignore since RequestedTopic will just remain null
                    _logger.LogWarning($"Requested Topic id not found: {id}");
                }
            }
        }
    }
}

