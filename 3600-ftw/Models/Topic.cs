namespace CSCI3600.Models;

using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

// POCO
// A View Model (NOT Page Model)
public class Topic
{
    public Guid Id { get; set; } = Guid.NewGuid();
    
    [Display(Name="Topic Title")]
    [StringLength(100, MinimumLength = 5)]
    [Required]
    public string? Title { get; set; }

    [Display(Name="Number of Hours")]
    [Range(1,45, ErrorMessage = "Must be between 1 and 45 hours")]
    public int? Hours { get; set; }
    
    [Display(Name="Topic Description")]
    [StringLength(1000)]
    public string? Description { get; set; }
}