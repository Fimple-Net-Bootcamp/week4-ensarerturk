using Microsoft.AspNetCore.Mvc;
using PetFriendTrackingAPI.Entities;
using PetFriendTrackingAPI.Services.Contract;

namespace PetFriendTrackingAPI.Controllers;

[ApiController]
[Route("api/v1/socialImpressions")]
public class SocialInteractionController : ControllerBase
{
    private readonly ISocialInteractionService _socialInteractionService;

    public SocialInteractionController(ISocialInteractionService socialInteractionService)
    {
        _socialInteractionService = socialInteractionService;
    }

    [HttpPost("{firstPetAnimalId}/{secondPetAnimalId}")]
    public async Task<ActionResult> StartSocialInteraction(int firstPetAnimalId, int secondPetAnimalId)
    {
        try
        {
            await _socialInteractionService.StartSocialInteractionAsync(firstPetAnimalId, secondPetAnimalId);
            return Ok("Social interaction between pets is initiated.");
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }

    [HttpGet("{petAnimalId}")]
    public async Task<ActionResult<IEnumerable<SocialInteraction>>> GetSocialInteractions(int petAnimalId)
    {
        try
        {
            var socialInteractions = await _socialInteractionService.GetByPetAnimalIdAsync(petAnimalId);

            return Ok(socialInteractions);
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }
}