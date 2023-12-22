namespace PetFriendTrackingAPI.DTO;

public class PostActivityDTO
{
    public string Type { get; set; }
    public DateTime StartDate { get; set; }
    public DateTime EndDate { get; set; }
    public int PetAnimalId { get; set; }
}