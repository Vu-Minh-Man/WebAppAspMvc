using Microsoft.EntityFrameworkCore;
using WebAppAspMvc.Models;

namespace WebAppAspMvc.Context
{
    public class WebAppDbContext : DbContext
    {
        public WebAppDbContext(DbContextOptions<WebAppDbContext> options) : base(options)
        {
        }

        public DbSet<Customer> Customers { get; set; }
        public DbSet<MembershipType> MembershipTypes { get; set; }
        public DbSet<Movie> Movies { get; set; }
        public DbSet<Genre> Genres { get; set; }

        // Naming Convention used in other SQL Management Systems
        //protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        //{
        //    optionsBuilder.UseSnakeCaseNamingConvention();
        //}
    }
}
