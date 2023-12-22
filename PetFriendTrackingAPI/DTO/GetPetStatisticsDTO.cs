namespace PetFriendTrackingAPI.DTO;

public class GetPetStatisticsDTO
{
    public List<GetHealthStatusDTO> HealthStatuses { get; set; }
    public List<GetActivityDTO> Activities { get; set; }
    public List<PetAnimalFoodDTO> PetAnimalFoods { get; set; }
}