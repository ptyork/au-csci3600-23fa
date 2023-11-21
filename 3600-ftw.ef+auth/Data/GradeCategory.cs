namespace CSCI3600.Data;

using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


public class GradeCategory
{
    [Key]
    public Guid CategoryId { get; set; } = Guid.NewGuid();
    
    [Display(Name="Grade Category Name")]
    [StringLength(100, MinimumLength = 3)]
    [Required]
    public string? Name { get; set; }

    [Display(Name="Grade Category Description")]
    [StringLength(1000)]
    public string? Description { get; set; }

    [Display(Name="Grade Category Weight")]
    [Range(0,100)]
    public decimal? Weight { get; set; }
    
    // Navigation property to access "children"
    public ICollection<GradeItem> GradeItems { get; set; } = new List<GradeItem>();

}