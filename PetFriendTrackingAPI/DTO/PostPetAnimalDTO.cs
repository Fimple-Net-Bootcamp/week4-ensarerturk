namespace PetFriendTrackingAPI.DTO;

public class PostPetAnimalDTO
{
    public string Name { get; set; }
    public string Type { get; set; }
    public DateTime BirthDate { get; set; } = DateTime.UtcNow;
    public int UserId { get; set; }
}