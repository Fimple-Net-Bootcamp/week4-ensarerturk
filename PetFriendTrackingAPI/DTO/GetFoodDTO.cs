namespace PetFriendTrackingAPI.DTO;

public class GetFoodDTO
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string Type { get; set; }
    public int Kalori { get; set; }
    public int Protein { get; set; }
    public int Oil { get; set; }
    public int Carbohydrate { get; set; }
}