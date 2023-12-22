namespace PetFriendTrackingAPI.Entities;

public class Food
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string Type { get; set; }
    public int Kalori { get; set; }
    public int Protein { get; set; }
    public int Oil { get; set; }
    public int Carbohydrate { get; set; }
    
    public virtual List<PetAnimalFood> PetAnimalFoods { get; set; }
}