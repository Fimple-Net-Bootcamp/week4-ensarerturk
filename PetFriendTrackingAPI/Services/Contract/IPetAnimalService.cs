using PetFriendTrackingAPI.DTO;

namespace PetFriendTrackingAPI.Services.Contract;

public interface IPetAnimalService
{
    Task<IEnumerable<GetPetAnimalDTO>> GetAllEAsync();
    Task<GetPetAnimalDTO> GetByIdAsync(int petAnimalId);
    Task<GetPetStatisticsDTO> GetStatisticsAsync(int petAnimalId);
    Task AddAsync(PostPetAnimalDTO petAnimalDTO);
    Task UpdatenAsync(int petAnimalId, PostPetAnimalDTO petAnimalDTO);
    Task RemoveAsync(int petAnimalId);
}