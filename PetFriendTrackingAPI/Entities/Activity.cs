using System.ComponentModel.DataAnnotations.Schema;

namespace PetFriendTrackingAPI.Entities;

public class Activity
{
    public int Id { get; set; }
    public string Type { get; set; }
    public DateTime StartDate { get; set; } = DateTime.UtcNow;
    public DateTime EndDate { get; set; } = DateTime.UtcNow;
    
    public int PetAnimalId { get; set; }
    
    [ForeignKey("PetAnimalId")]
    public virtual PetAnimal PetAnimal { get; set; }
}