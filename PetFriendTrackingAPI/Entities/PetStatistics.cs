namespace PetFriendTrackingAPI.Entities;

public class PetStatistics
{
    public List<HealthStatus> HealthStatuses { get; set; }
    public List<Activity> Activities { get; set; }
    public List<PetAnimalFood> PetAnimalFoods { get; set; }
}