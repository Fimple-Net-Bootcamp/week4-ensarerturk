using PetFriendTrackingAPI.Entities;

namespace PetFriendTrackingAPI.Repositories.Contracts;

public interface ISocialInteractionRepository
{
    Task AddAsync(SocialInteraction socialInteraction);
    Task<IEnumerable<SocialInteraction>> GetByPetAnimalIdAsync(int petAnimalId);
}