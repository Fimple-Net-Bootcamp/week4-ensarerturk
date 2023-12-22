using Microsoft.EntityFrameworkCore;
using PetFriendTrackingAPI.DBOperations;
using PetFriendTrackingAPI.Entities;
using PetFriendTrackingAPI.Repositories.Contracts;

namespace PetFriendTrackingAPI.Repositories;

public class SocialInteractionRepository : ISocialInteractionRepository
{
    private readonly PetDbContext _dbContext;

    public SocialInteractionRepository(PetDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task AddAsync(SocialInteraction socialInteraction)
    {
        _dbContext.SocialInteractions.Add(socialInteraction);
        await _dbContext.SaveChangesAsync();
    }

    public async Task<IEnumerable<SocialInteraction>> GetByPetAnimalIdAsync(int petAnimalId)
    {
        return await _dbContext.SocialInteractions
            .Where(si => si.PetAnimalId == petAnimalId)
            .ToListAsync();
    }
}