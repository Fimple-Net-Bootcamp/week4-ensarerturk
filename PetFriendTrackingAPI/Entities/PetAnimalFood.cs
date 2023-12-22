using System.ComponentModel.DataAnnotations.Schema;

namespace PetFriendTrackingAPI.Entities;

public class PetAnimalFood
{
    public int Id { get; set; }
    
    public int PetAnimalId { get; set; }

    [ForeignKey("PetAnimalId")]
    public virtual PetAnimal PetAnimal { get; set; }

    public int FoodId { get; set; }
    
    [ForeignKey("FoodId")]
    public virtual Food Food { get; set; }

    public int Amount { get; set; }
}