using PetFriendTrackingAPI.DTO;

namespace PetFriendTrackingAPI.Services.Contract;

public interface IUserService
{
    Task<IEnumerable<GetUserDTO>> GetAllAsync();
    Task<GetUserDTO> GetByIdAsync(int userId);
    Task AddAsync(PostUserDTO user);
    Task RemoveAsync(int userId);
    Task<GetPetStatisticsDTO> GetPetStatisticsAsync(int kullaniciId);
}