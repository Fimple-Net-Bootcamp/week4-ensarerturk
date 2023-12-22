using PetFriendTrackingAPI.DTO;

namespace PetFriendTrackingAPI.Services.Contract;

public interface ISocialInteractionService
{
    Task StartSocialInteractionAsync(int firstPetAnimalId, int secondPetAnimalId);
    Task<IEnumerable<GetSocialInteractionDTO>> GetByPetAnimalIdAsync(int petAnimalId);
}