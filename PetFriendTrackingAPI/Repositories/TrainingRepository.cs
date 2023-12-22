using Microsoft.EntityFrameworkCore;
using PetFriendTrackingAPI.DBOperations;
using PetFriendTrackingAPI.Entities;
using PetFriendTrackingAPI.Repositories.Contracts;

namespace PetFriendTrackingAPI.Repositories;

public class TrainingRepository : ITrainingRepository
{
    private readonly PetDbContext _dbContext;

    public TrainingRepository(PetDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task AddTrainingAsync(Training training)
    {
        _dbContext.Trainings.Add(training);
        await _dbContext.SaveChangesAsync();
    }

    public async Task<IEnumerable<Training>> GetByPetAnimalIdAsync(int petAnimalId)
    {
        return await _dbContext.Trainings
            .Where(t => t.PetAnimalId == petAnimalId)
            .ToListAsync();
    }
}