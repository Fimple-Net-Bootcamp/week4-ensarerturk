using PetFriendTrackingAPI.DTO;
using PetFriendTrackingAPI.Entities;

namespace PetFriendTrackingAPI.Services.Contract;

public interface IActivityService
{
    Task<IEnumerable<GetActivityDTO>> GetAllAsync();
    Task<GetActivityDTO> GetByPetAnimalIdAsync(int petAnimalId);
    Task AddAsync(PostActivityDTO activity);
    Task RemoveAsync(int activityId);
}