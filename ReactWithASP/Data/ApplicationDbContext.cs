using Microsoft.EntityFrameworkCore;
using ReactWithASP.Models;

namespace ReactWithASP.Data {

    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public DbSet<Category> Agents { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Reason> Reasons { get; set; }
        public DbSet<Detail> Details { get; set; }
        public DbSet<Client> Clients { get; set; }
        public DbSet<Case> Cases { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            
            modelBuilder.Entity<Agents>().ToTable("Agent");
            modelBuilder.Entity<Category>().ToTable("Category");
            modelBuilder.Entity<Reason>().ToTable("Reason");
            modelBuilder.Entity<Detail>().ToTable("Detail");
            modelBuilder.Entity<Client>().ToTable("Client");
            modelBuilder.Entity<Case>().ToTable("Cases");
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite("Data Source=Database/XLN-Database.db")
                .UseQueryTrackingBehavior(QueryTrackingBehavior.NoTracking) // Prevents locks on queries
                .EnableSensitiveDataLogging();  // Useful for debugging
        }

    }
}
