namespace PetFriendTrackingAPI.DTO;

public class GetTrainingDTO
{
    public int Id { get; set; }
    public string Type { get; set; }
    public DateTime StartDate { get; set; }
    public DateTime EndDate { get; set; }
}