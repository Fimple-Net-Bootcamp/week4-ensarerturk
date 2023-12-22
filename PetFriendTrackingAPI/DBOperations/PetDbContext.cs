using Microsoft.EntityFrameworkCore;
using PetFriendTrackingAPI.Entities;

namespace PetFriendTrackingAPI.DBOperations;

public class PetDbContext : DbContext
{
    public PetDbContext(DbContextOptions options) : base(options)
    {
    }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseLazyLoadingProxies();
    }
    
    public DbSet<User> Users { get; set; }
    public DbSet<PetAnimal> PetAnimals { get; set; }
    public DbSet<HealthStatus> HealthStatus { get; set; }
    public DbSet<Activity> Activities { get; set; }
    public DbSet<Food> Foods { get; set; }
    public DbSet<PetAnimalFood> PetAnimalFoods { get; set; }
    public DbSet<Training> Trainings { get; set; }
    public DbSet<SocialInteraction> SocialInteractions { get; set; }
}