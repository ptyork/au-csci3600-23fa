namespace CSCI3600.Data;

using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


public enum GradeItemType
{
    PaperTest, OnlineTest, Code, Multimedia, Other
}

public class GradeItem
{
    [Key]
    public Guid ItemId { get; set; } = Guid.NewGuid();
    
    [Display(Name="Grade Item Name")]
    [StringLength(100, MinimumLength = 3)]
    [Required]
    public string? Name { get; set; }

    [Display(Name="Grade Item Type")]
    [Required]
    public GradeItemType Type { get; set; }

    [Display(Name="Grade Item Description")]
    [StringLength(1000)]
    public string? Description { get; set; }

    [Display(Name="Grade Item Weight")]
    [Range(0,100)]
    public decimal? Weight { get; set; }
    
    
    // Foreign Key field (referencing "parent")
    // [ForeignKey("GradeCategory")]
    [Display(Name="Grade Category")]
    public Guid GradeCategoryId { get; set; }
    
    // Navigation property (referencing "parent")
    public GradeCategory? GradeCategory { get; set; }
}