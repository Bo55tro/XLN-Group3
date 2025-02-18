using Microsoft.EntityFrameworkCore;
using ReactWithASP.Models;

namespace ReactWithASP.Data {

    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public DbSet<Category> Categories { get; set; } // ✅ Use plural naming
        public DbSet<Reason> Reasons { get; set; }
        public DbSet<Detail> Details { get; set; }
        public DbSet<Client> Clients { get; set; }
        public DbSet<Case> Cases { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            
            modelBuilder.Entity<Category>().ToTable("Category");
            modelBuilder.Entity<Reason>().ToTable("Reason");
            modelBuilder.Entity<Detail>().ToTable("Detail");
            modelBuilder.Entity<Client>().ToTable("Client");
            modelBuilder.Entity<Case>().ToTable("Cases"); // ✅ Ensure table names match
        }
    }
}
