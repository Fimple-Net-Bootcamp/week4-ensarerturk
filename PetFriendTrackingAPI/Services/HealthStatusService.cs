using AutoMapper;
using PetFriendTrackingAPI.DTO;
using PetFriendTrackingAPI.Entities;
using PetFriendTrackingAPI.Repositories.Contracts;
using PetFriendTrackingAPI.Services.Contract;

namespace PetFriendTrackingAPI.Services;

public class HealthStatusService : IHealthStatusService
{
    private readonly IHealthStatusRepository _healthStatusRepository;
    private readonly IMapper _mapper;

    public HealthStatusService(IHealthStatusRepository healthStatusRepository, IMapper mapper)
    {
        _healthStatusRepository = healthStatusRepository;
        _mapper = mapper;
    }

    public async Task<GetHealthStatusDTO> GetByIdAsync(int healthStatusId)
    {
        var healthStatus = await _healthStatusRepository.GetByIdAsync(healthStatusId);
        return _mapper.Map<GetHealthStatusDTO>(healthStatus);
    }

    public async Task AdduAsync(PostHealthStatusDTO healthStatusDto)
    {
        var healthStatus = _mapper.Map<HealthStatus>(healthStatusDto);
        await _healthStatusRepository.AddSAsync(healthStatus);
    }

    public async Task UpdateAsync(int petAnimalId, PatchHealthStatusDTO healthStatusDTO)
    {
        var healthStatus = _mapper.Map<HealthStatus>(healthStatusDTO);
        await _healthStatusRepository.UpdateAsync(petAnimalId, healthStatus);
    }
}