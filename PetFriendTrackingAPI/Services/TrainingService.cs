using AutoMapper;
using PetFriendTrackingAPI.DTO;
using PetFriendTrackingAPI.Entities;
using PetFriendTrackingAPI.Repositories.Contracts;
using PetFriendTrackingAPI.Services.Contract;

namespace PetFriendTrackingAPI.Services;

public class TrainingService : ITrainingService
{
    private readonly ITrainingRepository _trainingRepository;
    private readonly IMapper _mapper;

    public TrainingService(ITrainingRepository trainingRepository, IMapper mapper)
    {
        _trainingRepository = trainingRepository;
        _mapper = mapper;
    }

    public async Task AddTrainingAsync(PostTrainingDTO training)
    {
        var mappedTraining = _mapper.Map<Training>(training);
        await _trainingRepository.AddTrainingAsync(mappedTraining);
    }

    public async Task<IEnumerable<GetTrainingDTO>> GetByPetAnimalIdAsync(int petAnimalId)
    {
        var trainings = await _trainingRepository.GetByPetAnimalIdAsync(petAnimalId);
        return _mapper.Map<IEnumerable<GetTrainingDTO>>(trainings);
    }
}