using PetFriendTrackingAPI.Entities;

namespace PetFriendTrackingAPI.Repositories.Contracts;

public interface IHealthStatusRepository
{
    Task<HealthStatus> GetByIdAsync(int healthStatusId);
    Task AddSAsync(HealthStatus healthStatus);
    Task UpdateAsync(int petAnimalId, HealthStatus healthStatus);
}
