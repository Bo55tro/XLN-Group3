using Microsoft.EntityFrameworkCore;
using ReactWithASP.Models;

namespace ReactWithASP.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        // DbSet for the Agent table
        public DbSet<Agent> Agents { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Map the table name to the "Agents" table
            modelBuilder.Entity<Agent>().ToTable("Agents");
        }
    }
}
