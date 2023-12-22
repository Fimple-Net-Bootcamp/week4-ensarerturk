using PetFriendTrackingAPI.DTO;
using PetFriendTrackingAPI.Entities;

namespace PetFriendTrackingAPI.Services.Contract;

public interface IFoodService
{
    Task<IEnumerable<GetFoodDTO>> GetAllAsync();
    Task<GetFoodDTO> GetByIdAsync(int foodId);
    Task AddAsync(PostFoodDTO besin);
    Task GiveFoodAsync(int petAnimalId, string foodName);
    Task UpdateAsync(PostFoodDTO food);
    Task RemoveAsync(int foodId);
}