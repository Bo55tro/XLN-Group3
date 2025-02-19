using Microsoft.EntityFrameworkCore;

public class ApplicationDbContext : DbContext
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
        : base(options) { }

    // Define your database tables here
    public DbSet<Agent> Agents { get; set; }  // Example table
}

public class Agent  // Example model (you can change this)
{
    public int agentId { get; set; }
    public string agentName { get; set; }
    public string agentUsername { get; set; }
    public string agentPassword { get; set; }
}
