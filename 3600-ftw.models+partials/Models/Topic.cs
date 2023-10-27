namespace CSCI3600.Models;

// POCO
// A View Model (NOT Page Model)
public class Topic
{
    public Guid Id { get; set; } = Guid.NewGuid();
    public string? Description { get; set; }
    public int Hours { get; set; }
}