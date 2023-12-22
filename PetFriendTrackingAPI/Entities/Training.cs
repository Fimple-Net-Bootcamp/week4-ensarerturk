namespace PetFriendTrackingAPI.Entities;

public class Training
{
    public int Id { get; set; }
    public string Type { get; set; }
    public DateTime StartDate { get; set; }
    public DateTime EndDate { get; set; }

    public int PetAnimalId { get; set; }
    public virtual PetAnimal PetAnimal { get; set; }
}   