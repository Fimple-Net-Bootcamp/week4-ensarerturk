namespace PetFriendTrackingAPI.DTO;

public class GetPetAnimalDTO
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string Type { get; set; }
    public DateTime BirthDate { get; set; } = DateTime.UtcNow;
    public int UserId { get; set; }
    public List<PostHealthStatusDTO> HealthStatus { get; set; }
    public List<PostActivityDTO> Activities { get; set; }
    public List<PetAnimalFoodDTO> PetAnimalFoods { get; set; }
    public List<GetTrainingDTO> Trainings { get; set; }

}