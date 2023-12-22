namespace PetFriendTrackingAPI.DTO;

public class GetHealthStatusDTO
{
    public int Id { get; set; }
    public string Description { get; set; }
    public DateTime Date { get; set; }
    public int PetAnimalId { get; set; }
}