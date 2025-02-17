using Microsoft.EntityFrameworkCore;
using ReactWithASP.Models;  // Ensure this matches your namespace

namespace ReactWithASP.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        // Add DbSet properties for each table
        public DbSet<Category> Categories { get; set; }
        public DbSet<Reason> Reasons { get; set; }
        public DbSet<Detail> Details { get; set; }


    }
}
