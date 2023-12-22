using AutoMapper;
using PetFriendTrackingAPI.DTO;
using PetFriendTrackingAPI.Entities;
using PetFriendTrackingAPI.Repositories.Contracts;
using PetFriendTrackingAPI.Services.Contract;

namespace PetFriendTrackingAPI.Services;

public class SocialInteractionService : ISocialInteractionService
{
    private readonly ISocialInteractionRepository _socialInteractionRepository;
    private readonly IMapper _mapper;


    public SocialInteractionService(ISocialInteractionRepository socialInteractionRepository, IMapper mapper)
    {
        _socialInteractionRepository = socialInteractionRepository;
        _mapper = mapper;
    }

    public async Task StartSocialInteractionAsync(int petAnimalId1, int petAnimalId2)
    {
        var socialInteraction1 = new SocialInteraction { PetAnimalId = petAnimalId1 };
        var socialInteraction2 = new SocialInteraction { PetAnimalId = petAnimalId2 };

        await _socialInteractionRepository.AddAsync(socialInteraction1);
        await _socialInteractionRepository.AddAsync(socialInteraction2);
    }

    public async Task<IEnumerable<GetSocialInteractionDTO>> GetByPetAnimalIdAsync(int petAnimalId)
    {
        var socialIntegrations = await _socialInteractionRepository.GetByPetAnimalIdAsync(petAnimalId);
        return _mapper.Map<IEnumerable<GetSocialInteractionDTO>>(socialIntegrations);
    }
}