using Microsoft.EntityFrameworkCore;
using PetFriendTrackingAPI.DBOperations;
using PetFriendTrackingAPI.Entities;
using PetFriendTrackingAPI.Repositories.Contracts;

namespace PetFriendTrackingAPI.Repositories;

public class PetAnimalRepository : IPetAnimalRepository
{
    private readonly PetDbContext _dbContext;

    public PetAnimalRepository(PetDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task<IEnumerable<PetAnimal>> GetAllAsync()
    {
        return await _dbContext.PetAnimals.ToListAsync();
    }

    public async Task<PetAnimal> GetByIdAsync(int petAnimalId)
    {
        return await _dbContext.PetAnimals.FindAsync(petAnimalId);
    }

    public async Task<IEnumerable<HealthStatus>> GetHealthStatusesAsync(int petAnimalId)
    {
        var byIdAsync = GetByIdAsync(petAnimalId);


        return await _dbContext.HealthStatus
            .Where(hs => hs.PetAnimalId == petAnimalId)
            .ToListAsync();
    }

    public async Task<IEnumerable<Activity>> GetActivitiesAsync(int petAnimalId)
    {
        return await _dbContext.Activities
            .Where(a => a.PetAnimalId == petAnimalId)
            .ToListAsync();
    }

    public async Task<IEnumerable<PetAnimalFood>> GetPetAnimalFoodsAsync(int petAnimalId)
    {
        return await _dbContext.PetAnimalFoods
            .Where(paf => paf.PetAnimalId == petAnimalId)
            .ToListAsync();
    }

    public async Task AddAsync(PetAnimal petAnimal)
    {
        _dbContext.PetAnimals.Add(petAnimal);
        await _dbContext.SaveChangesAsync();
    }

    public async Task UpdateAsync(int petAnimalId, PetAnimal petAnimal)
    {
        var findAnimal = await _dbContext.PetAnimals.FindAsync(petAnimalId);

        if (findAnimal != null)
        {
            findAnimal.Name = petAnimal.Name;
            findAnimal.Type = petAnimal.Type;
            findAnimal.BirthDate = petAnimal.BirthDate;
            findAnimal.UserId = petAnimal.UserId;
            await _dbContext.SaveChangesAsync();
        }
    }

    public async Task RemoveAsync(int petAnimalId)
    {
        var evcilHayvan = await _dbContext.PetAnimals.FindAsync(petAnimalId);

        if (evcilHayvan != null)
        {
            _dbContext.PetAnimals.Remove(evcilHayvan);
            await _dbContext.SaveChangesAsync();
            return;
        }

        throw new BadHttpRequestException("The pet could not be deleted.");
    }
}