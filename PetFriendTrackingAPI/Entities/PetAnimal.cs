using System.ComponentModel.DataAnnotations.Schema;

namespace PetFriendTrackingAPI.Entities;

public class PetAnimal
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string Type { get; set; }
    public DateTime BirthDate { get; set; } = DateTime.UtcNow;
    
    public int UserId { get; set; }
    
    [ForeignKey("UserId")]
    public virtual User User { get; set; }
    
    public virtual List<HealthStatus> HealthStatus { get; set; }
    public virtual List<Activity> Activities { get; set; }
    public virtual List<PetAnimalFood> PetAnimalFoods { get; set; }
    public virtual List<Training> Trainings { get; set; }
}