﻿using System.ComponentModel.DataAnnotations.Schema;

namespace PetFriendTrackingAPI.Entities;

public class HealthStatus
{
    public int Id { get; set; }
    public string Description { get; set; }
    public DateTime Date { get; set; } = DateTime.UtcNow;
    
    public int PetAnimalId { get; set; }
    
    [ForeignKey("PetAnimalId")]
    public virtual PetAnimal PetAnimal { get; set; }
}