using PetFriendTrackingAPI.Entities;

namespace PetFriendTrackingAPI.Repositories.Contracts;

public interface IActivityRepository
{
    Task<IEnumerable<Activity>> GetAllAsync();
    Task<Activity> GetByPetAnimalIdAsync(int petAnimalId);
    Task AddAsync(Activity activity);
    Task RemoveAsync(int activityId);
}