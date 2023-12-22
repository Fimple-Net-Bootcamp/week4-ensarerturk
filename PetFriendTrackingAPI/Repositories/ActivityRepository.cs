using Microsoft.EntityFrameworkCore;
using PetFriendTrackingAPI.DBOperations;
using PetFriendTrackingAPI.Entities;
using PetFriendTrackingAPI.Repositories.Contracts;

namespace PetFriendTrackingAPI.Repositories;

public class ActivityRepository : IActivityRepository
{
    private readonly PetDbContext _dbContext;

    public ActivityRepository(PetDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task<IEnumerable<Activity>> GetAllAsync()
    {
        return await _dbContext.Activities.ToListAsync();
    }

    public async Task<Activity> GetByPetAnimalIdAsync(int petAnimalId)
    {
        var petAnimal = await _dbContext.PetAnimals.FindAsync(petAnimalId);

        return petAnimal != null ? petAnimal.Activities.FirstOrDefault() : null;
    }

    public async Task AddAsync(Activity activity)
    {
        _dbContext.Activities.Add(activity);
        await _dbContext.SaveChangesAsync();
    }

    public async Task RemoveAsync(int activityId)
    {
        var activity = await _dbContext.Activities.FindAsync(activityId);
        if (activity != null)
        {
            _dbContext.Activities.Remove(activity);
            await _dbContext.SaveChangesAsync();
        }

        throw new BadHttpRequestException("Unable to delete activity.");
    }
}