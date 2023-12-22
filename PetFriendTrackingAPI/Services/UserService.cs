using AutoMapper;
using PetFriendTrackingAPI.DTO;
using PetFriendTrackingAPI.Entities;
using PetFriendTrackingAPI.Repositories.Contracts;
using PetFriendTrackingAPI.Services.Contract;

namespace PetFriendTrackingAPI.Services;

public class UserService : IUserService
{
    private readonly IUserRepository _userRepository;
    private readonly IMapper _mapper;

    public UserService(IUserRepository userRepository, IMapper mapper)
    {
        _userRepository = userRepository;
        _mapper = mapper;
    }

    public async Task<IEnumerable<GetUserDTO>> GetAllAsync()
    {
        var users = await _userRepository.GetAllAsync();
        return _mapper.Map<IEnumerable<GetUserDTO>>(users);
    }

    public async Task<GetUserDTO> GetByIdAsync(int userId)
    {
        var user = await _userRepository.GetByIdAsync(userId);
        return _mapper.Map<GetUserDTO>(user);
    }

    public async Task AddAsync(PostUserDTO user)
    {
        var mappedUser = _mapper.Map<User>(user);
        await _userRepository.AddAsync(mappedUser);
    }

    public async Task RemoveAsync(int userId)
    {
        await _userRepository.RemoveAsync(userId);
    }

    public async Task<GetPetStatisticsDTO> GetPetStatisticsAsync(int kullaniciId)
    {
        var petStatistics = await _userRepository.GetPetStatisticsAsync(kullaniciId);
        return _mapper.Map<GetPetStatisticsDTO>(petStatistics);
    }
}