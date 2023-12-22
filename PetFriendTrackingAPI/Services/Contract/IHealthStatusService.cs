using PetFriendTrackingAPI.DTO;

namespace PetFriendTrackingAPI.Services.Contract;

public interface IHealthStatusService
{
    Task<GetHealthStatusDTO> GetByIdAsync(int healthStatusId);
    Task AdduAsync(PostHealthStatusDTO healthStatus);
    Task UpdateAsync(int petAnimalId, PatchHealthStatusDTO healthStatus);
}