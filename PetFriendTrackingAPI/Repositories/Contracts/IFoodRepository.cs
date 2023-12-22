using PetFriendTrackingAPI.Entities;

namespace PetFriendTrackingAPI.Repositories.Contracts;

public interface IFoodRepository
{
    Task<IEnumerable<Food>> GetAllAsync();
    Task<Food> GetnByIdAsync(int foodId);
    Task AddAsync(Food besin);
    Task GiveFoodAsync(int petAnimalId, string foodName);
    Task UpdateAsync(Food food);
    Task RemoveAsync(int foodId);
}