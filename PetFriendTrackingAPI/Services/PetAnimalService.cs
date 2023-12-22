using AutoMapper;
using PetFriendTrackingAPI.DTO;
using PetFriendTrackingAPI.Entities;
using PetFriendTrackingAPI.Repositories.Contracts;
using PetFriendTrackingAPI.Services.Contract;

namespace PetFriendTrackingAPI.Services;

public class PetAnimalService : IPetAnimalService
{
    private readonly IPetAnimalRepository _petAnimalRepository;
    private readonly IMapper _mapper;

    public PetAnimalService(IPetAnimalRepository petAnimalRepository, IMapper mapper)
    {
        _petAnimalRepository = petAnimalRepository;
        _mapper = mapper;
    }

    public async Task<IEnumerable<GetPetAnimalDTO>> GetAllEAsync()
    {
        var petAnimals = await _petAnimalRepository.GetAllAsync();
        return _mapper.Map<IEnumerable<GetPetAnimalDTO>>(petAnimals);
    }

    public async Task<GetPetAnimalDTO> GetByIdAsync(int petAnimalId)
    {
        var petAnimal = await _petAnimalRepository.GetByIdAsync(petAnimalId);
        return _mapper.Map<GetPetAnimalDTO>(petAnimal);
    }

    public async Task<GetPetStatisticsDTO> GetStatisticsAsync(int petAnimalId)
    {
        var petStatisticsDTO = new GetPetStatisticsDTO
        {
            HealthStatuses =
                _mapper.Map<List<GetHealthStatusDTO>>(await _petAnimalRepository.GetHealthStatusesAsync(petAnimalId)),
            Activities = _mapper.Map<List<GetActivityDTO>>(await _petAnimalRepository.GetActivitiesAsync(petAnimalId)),
            PetAnimalFoods =
                _mapper.Map<List<PetAnimalFoodDTO>>(await _petAnimalRepository.GetPetAnimalFoodsAsync(petAnimalId))
        };

        return petStatisticsDTO;
    }

    public async Task AddAsync(PostPetAnimalDTO petAnimalDTO)
    {
        var petAnimal = _mapper.Map<PetAnimal>(petAnimalDTO);
        await _petAnimalRepository.AddAsync(petAnimal);
    }

    public async Task UpdatenAsync(int petAnimalId, PostPetAnimalDTO petAnimalDTO)
    {
        var petAnimal = _mapper.Map<PetAnimal>(petAnimalDTO);
        await _petAnimalRepository.UpdateAsync(petAnimalId, petAnimal);
    }

    public async Task RemoveAsync(int petAnimalId)
    {
        await _petAnimalRepository.RemoveAsync(petAnimalId);
    }
}