#pragma warning disable CS8618
using Microsoft.EntityFrameworkCore;
namespace Vital.Models;

public class MyContext : DbContext 
{ 
    public MyContext(DbContextOptions options) : base(options) { }
    public DbSet<User> Users {get; set;}
    public DbSet<Owner> Owners {get; set;}
}