namespace CSCI3600.Data;

using System.ComponentModel.DataAnnotations;

public class FeedbackItem
{
    public int? Id { get; set; }
    
    [Display(Name="Date Posted")]
    public DateTime PostedAt { get; set; } = DateTime.Now;

    [Display(Name="Rating")]
    [Range(1, 5)]
    public int Rating { get; set; } = 0;

    [Display(Name="Feedback Text")]
    [StringLength(1000, MinimumLength = 3)]
    [Required]
    public string Text { get; set; } = "";

    [Display(Name="Email Address")]
    [EmailAddress]
    [Required]
    public string Email { get; set; } = "";

}