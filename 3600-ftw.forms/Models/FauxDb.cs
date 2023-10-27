using CSCI3600.Models;

public static class FauxDb
{
    public static HashSet<Topic> Topics { get; }

    static FauxDb()
    {
        var baseTopics = new List<Topic>
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

        Topics = new HashSet<Topic>(baseTopics, new TopicEqualityComparer());
    }

    public static bool Add<T>(T obj)
    {
        var topic = obj as Topic;
        if (topic != null && !Topics.Contains(topic))
        {
            Topics.Add(topic);
            return true;
        }
        return false;
    }


    public static bool Update<T>(T obj)
    {
        var topic = obj as Topic;
        if (topic != null && Topics.Contains(topic))
        {
            Topics.Remove(topic);
            Topics.Add(topic);
            return true;
        }
        return false;
    }

    public static bool Delete<T>(T obj)
    {
        var topic = obj as Topic;
        if (topic != null && Topics.Contains(topic))
        {
            Topics.Remove(topic);
            return true;
        }
        return false;
    }

    private class TopicEqualityComparer : IEqualityComparer<Topic>
    {
        public bool Equals(Topic? t1, Topic? t2)
        {
            if (ReferenceEquals(t1, t2))
                return true;

            if (t2 is null || t1 is null)
                return false;

            return  t1.Id == t2.Id;
        }

        public int GetHashCode(Topic t) => t.Id.GetHashCode();
    }
}