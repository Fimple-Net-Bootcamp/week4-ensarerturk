using PetFriendTrackingAPI.DBOperations;
using PetFriendTrackingAPI.Entities;
using PetFriendTrackingAPI.Repositories.Contracts;

namespace PetFriendTrackingAPI.Repositories;

public class HealthStatusRepository : IHealthStatusRepository
{
    private readonly PetDbContext _dbContext;

    public HealthStatusRepository(PetDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task<HealthStatus> GetByIdAsync(int healthStatusId)
    {
        var petAnimal = await _dbContext.PetAnimals.FindAsync(healthStatusId);

        if (petAnimal != null)
        {
            return petAnimal.HealthStatus.FirstOrDefault();
        }

        return null;
    }

    public async Task AddSAsync(HealthStatus healthStatus)
    {
        _dbContext.HealthStatus.Add(healthStatus);
        await _dbContext.SaveChangesAsync();
    }

    public async Task UpdateAsync(int petAnimalId, HealthStatus healthStatus)
    {
        var evcilHayvan = await _dbContext.PetAnimals.FindAsync(petAnimalId);

        if (evcilHayvan != null)
        {
            foreach (var durumu in evcilHayvan.HealthStatus)
            {
                durumu.Description = healthStatus.Description;
                durumu.Date = healthStatus.Date;
            }

            await _dbContext.SaveChangesAsync();
        }
    }
}