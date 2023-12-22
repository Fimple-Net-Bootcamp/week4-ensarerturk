namespace PetFriendTrackingAPI.Entities;

public class User
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string Surname { get; set; }
    public string Email { get; set; }
    public string Password { get; set; }
    
    public virtual List<PetAnimal> PetAnimals { get; set; }
}