using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace CSCI3600.Data;

public class MyDataContext : IdentityDbContext<IdentityUser>
{
    public DbSet<Topic> Topics { get; set; }
    public DbSet<GradeCategory> GradeCategories { get; set; }
    public DbSet<GradeItem> GradeItems { get; set; }






    public MyDataContext(DbContextOptions<MyDataContext> options)
        : base(options)
    {
    }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);
        // Customize the ASP.NET Identity model and override the defaults if needed.
        // For example, you can rename the ASP.NET Identity table names and more.
        // Add your customizations after calling base.OnModelCreating(builder);
    }
}
