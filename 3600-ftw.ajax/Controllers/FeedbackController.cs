using System.Collections;
using CSCI3600.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using NuGet.Protocol;

namespace CSCI3600.API;

[ApiController]
[Route("/api/[controller]")]
public class FeedbackController : ControllerBase
{

    // PRIVATE MODEL ATTRIBUTES & CONSTRUCTOR
    private readonly ILogger<FeedbackController> _logger;
    private readonly MyDataContext _context;

    public FeedbackController(ILogger<FeedbackController> logger, MyDataContext context)
    {
        _logger = logger;
        _context = context;
    }

    [HttpGet]
    public async Task<IEnumerable<FeedbackItem>> GetFeedbackAsync()
    {
        return await _context.Feedback
                             .OrderByDescending(f => f.PostedAt)
                             .ToListAsync();
    }

    [HttpPost]
    public async Task<ActionResult> PostFeedbackAsync(FeedbackItem item)
    {
        _logger.LogInformation($"trying to add {item.ToJson()}");
        if (!ModelState.IsValid || _context.Feedback == null || item == null)
        {
            _logger.LogError(ModelState.ToJson());
            return BadRequest();
        }

        try
        {
            _logger.LogInformation("Adding");
            _context.Feedback.Add(item);
            _logger.LogInformation("Saving");
            await _context.SaveChangesAsync();
            _logger.LogInformation("Success");
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Unable to Add Feedback");
            return StatusCode(500, ex);
        }

        return Ok();
    }

}