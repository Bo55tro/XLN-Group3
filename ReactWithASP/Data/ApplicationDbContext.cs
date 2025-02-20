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
        public DbSet<Case> Cases { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Client> Clients { get; set; }
        public DbSet<Detail> Details { get; set; }
        public DbSet<Reason> Reasons { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Map the table name to the "Agents" table
            modelBuilder.Entity<Agent>().ToTable("Agents");
            modelBuilder.Entity<Case>().ToTable("Cases");
            modelBuilder.Entity<Category>().ToTable("Categories");
            modelBuilder.Entity<Client>().ToTable("Clients");
            modelBuilder.Entity<Detail>().ToTable("Details");
            modelBuilder.Entity<Reason>().ToTable("Reasons");
        }
    }
}
