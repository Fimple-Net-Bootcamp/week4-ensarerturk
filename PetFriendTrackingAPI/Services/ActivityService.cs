using AutoMapper;
using PetFriendTrackingAPI.DTO;
using PetFriendTrackingAPI.Entities;
using PetFriendTrackingAPI.Repositories.Contracts;
using PetFriendTrackingAPI.Services.Contract;

namespace PetFriendTrackingAPI.Services;

public class ActivityService : IActivityService
{
    private readonly IActivityRepository _activityRepository;
    private readonly IMapper _mapper;

    public ActivityService(IActivityRepository activityRepository, IMapper mapper)
    {
        _activityRepository = activityRepository;
        _mapper = mapper;
    }

    public async Task<IEnumerable<GetActivityDTO>> GetAllAsync()
    {
        var activities = await _activityRepository.GetAllAsync();
        return _mapper.Map<IEnumerable<GetActivityDTO>>(activities);
    }

    public async Task<GetActivityDTO> GetByPetAnimalIdAsync(int petAnimalId)
    {
        var petAnimal = await _activityRepository.GetByPetAnimalIdAsync(petAnimalId);
        return _mapper.Map<GetActivityDTO>(petAnimal);
    }

    public async Task AddAsync(PostActivityDTO activity)
    {
        var activities = _mapper.Map<Activity>(activity);
        await _activityRepository.AddAsync(activities);
    }
    
    public async Task RemoveAsync(int activityId)
    {
        await _activityRepository.RemoveAsync(activityId);
    }
}