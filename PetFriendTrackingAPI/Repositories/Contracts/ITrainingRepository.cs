using PetFriendTrackingAPI.Entities;

namespace PetFriendTrackingAPI.Repositories.Contracts;

public interface ITrainingRepository
{
    Task AddTrainingAsync(Training training);
    Task<IEnumerable<Training>> GetByPetAnimalIdAsync(int petAnimalId);
}