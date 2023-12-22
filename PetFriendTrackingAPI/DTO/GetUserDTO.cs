namespace PetFriendTrackingAPI.DTO;

public class GetUserDTO
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string Surname { get; set; }
    public string Email { get; set; }
    public string Password { get; set; }
    
    public List<PostPetAnimalDTO> PetAnimals { get; set; }
}