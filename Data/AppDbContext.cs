using Microsoft.EntityFrameworkCore;
using CRUD_APP1.Models;
namespace CRUD_APP1.Data;

public class AppDbContext : DbContext
//we are creating our own class called AppDbContext.
//AppDbContext is our EF Core DbContext
//DbContent is provided by EFCore.
{
    
    public AppDbContext(DbContextOptions<AppDbContext> options)
        : base(options)
        {}
        //this is our constructor

        //configurations made within program.cs file will be passed to this constructor.
        //passing is done by base(option)

        public DbSet<Product> Products{ get;set;}
    //DbSet<Product> means telling EFCore to manage a collection of Product records in my database.
    //so now EF core will recognize this and create Products wwhich will have id, name, price, and quantity.

    //later when somebody does _context.Products : we can get access to Products table through EFCore.
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Product>()
        .Property(p=>p.Price)
        .HasPrecision(18,2);
    }
    
    
    
}