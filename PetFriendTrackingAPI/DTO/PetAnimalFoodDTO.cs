namespace PetFriendTrackingAPI.DTO;

public class PetAnimalFoodDTO
{
    public int Id { get; set; }
    public int PetAnimalId { get; set; }
    public int FoodId { get; set; }
    public int Amount { get; set; }
}