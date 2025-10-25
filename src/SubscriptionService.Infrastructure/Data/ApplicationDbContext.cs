using Microsoft.EntityFrameworkCore;
using SimpleSubscription.Domain.Entities;

namespace SimpleSubscription.Infrastructure.Data;

public class ApplicationDbContext : DbContext
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
        : base(options)
    {
        Database.EnsureCreated();
    }

    public DbSet<Plan> Plans => Set<Plan>();
    public DbSet<Subscription> Subscriptions => Set<Subscription>();

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.Entity<Plan>().HasData(
            new Plan(name: "Basic", price: 10) { Id = 1 },
            new Plan(name: "Standard", price: 20) { Id = 2 },
            new Plan(name: "Premium", price: 30) { Id = 3 }
        );
    }
}
