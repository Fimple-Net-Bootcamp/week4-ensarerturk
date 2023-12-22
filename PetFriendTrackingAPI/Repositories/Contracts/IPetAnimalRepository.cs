using PetFriendTrackingAPI.Entities;

namespace PetFriendTrackingAPI.Repositories.Contracts;

public interface IPetAnimalRepository
{
    Task<IEnumerable<PetAnimal>> GetAllAsync();
    Task<PetAnimal> GetByIdAsync(int petAnimalId);
    Task<IEnumerable<HealthStatus>> GetHealthStatusesAsync(int petAnimalId);
    Task<IEnumerable<Activity>> GetActivitiesAsync(int petAnimalId);
    Task<IEnumerable<PetAnimalFood>> GetPetAnimalFoodsAsync(int petAnimalId);
    Task AddAsync(PetAnimal petAnimal);
    Task UpdateAsync(int petAnimalId, PetAnimal petAnimal);
    Task RemoveAsync(int petAnimalId);
}