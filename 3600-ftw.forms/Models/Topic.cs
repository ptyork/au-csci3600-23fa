namespace CSCI3600.Models;

using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

// POCO
// A View Model (NOT Page Model)
public class Topic
{
    public Guid Id { get; set; } = Guid.NewGuid();
    
    [Display(Name="Topic Description")]
    [DataType(DataType.Text)]
    [Required]
    public string? Description { get; set; }
    
    [Display(Name="Number of Hours")]
    public int Hours { get; set; }
}