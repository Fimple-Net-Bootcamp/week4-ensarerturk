using PetFriendTrackingAPI.Entities;

namespace PetFriendTrackingAPI.Repositories.Contracts;

public interface IUserRepository
{
    Task<IEnumerable<User>> GetAllAsync();
    Task<User> GetByIdAsync(int userId);
    Task AddAsync(User user);
    Task RemoveAsync(int userId);
    Task<PetStatistics> GetPetStatisticsAsync(int kullaniciId);
}