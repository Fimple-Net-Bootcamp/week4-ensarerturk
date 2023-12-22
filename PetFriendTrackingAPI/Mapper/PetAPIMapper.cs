using AutoMapper;
using Microsoft.AspNetCore.Http.HttpResults;
using PetFriendTrackingAPI.DTO;
using PetFriendTrackingAPI.Entities;

namespace PetFriendTrackingAPI.Mapper;

public class PetAPIMapper : Profile
{
    public PetAPIMapper()
    {
        CreateMap<Activity, GetActivityDTO>().ReverseMap();
        CreateMap<Activity, PostActivityDTO>().ReverseMap();

        CreateMap<Food, GetFoodDTO>().ReverseMap();
        CreateMap<Food, PostFoodDTO>().ReverseMap();

        CreateMap<HealthStatus, GetHealthStatusDTO>().ReverseMap();
        CreateMap<HealthStatus, PostHealthStatusDTO>().ReverseMap();
        CreateMap<HealthStatus, PatchHealthStatusDTO>().ReverseMap();

        CreateMap<PetAnimal, GetPetAnimalDTO>().ReverseMap();
        CreateMap<PetAnimal, PostPetAnimalDTO>().ReverseMap();

        CreateMap<User, GetUserDTO>().ReverseMap();
        CreateMap<User, PostUserDTO>().ReverseMap();

        CreateMap<PetAnimalFood, PetAnimalFoodDTO>().ReverseMap();

        CreateMap<PetStatistics, GetPetStatisticsDTO>().ReverseMap();

        CreateMap<Training, GetTrainingDTO>().ReverseMap();
        CreateMap<Training, PostTrainingDTO>().ReverseMap();

        CreateMap<SocialInteraction, GetSocialInteractionDTO>().ReverseMap();
    }
}