using PetFriendTrackingAPI.DTO;

namespace PetFriendTrackingAPI.Services.Contract;

public interface ITrainingService
{
    Task AddTrainingAsync(PostTrainingDTO training);
    Task<IEnumerable<GetTrainingDTO>> GetByPetAnimalIdAsync(int petAnimalId);
}