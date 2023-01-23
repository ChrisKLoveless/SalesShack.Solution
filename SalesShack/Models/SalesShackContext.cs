using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;


namespace SalesShack.Models 
{
  public class SalesShackContext : IdentityDbContext<User> 
  {
    public DbSet<User> Users { get; set; } 
    public DbSet<Product> Products { get; set; } 
    public DbSet<Sale> Sales { get; set; } 
    public DbSet<Client> Clients { get; set; } 
    public SalesShackContext(DbContextOptions options) : base(options) { } 
  }
}