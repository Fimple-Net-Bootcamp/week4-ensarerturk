using FluentValidation;
using Microsoft.AspNetCore.Mvc;
using PetFriendTrackingAPI.DTO;
using PetFriendTrackingAPI.Services.Contract;

namespace PetFriendTrackingAPI.Controllers;

[Route("api/v1/activities")]
[ApiController]
public class ActivityController : ControllerBase
{
    private readonly IActivityService _activityService;
    private readonly IValidator<PostActivityDTO> _validator;

    public ActivityController(IActivityService activityService, IValidator<PostActivityDTO> validator)
    {
        _activityService = activityService;
        _validator = validator;
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<GetActivityDTO>>> Get()
    {
        try
        {
            var activities = await _activityService.GetAllAsync();
            return Ok(activities);
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }

    [HttpGet("{petAnimalId}")]
    public async Task<ActionResult<GetActivityDTO>> GetByPetAnimalId(int evcilHayvanId)
    {
        try
        {
            var activities = await _activityService.GetByPetAnimalIdAsync(evcilHayvanId);
            return Ok(activities);
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }

    [HttpPost]
    public async Task<ActionResult> Post([FromBody] PostActivityDTO activity)
    {
        try
        {
            var validationResult = _validator.Validate(activity);

            if (!validationResult.IsValid)
            {
                return BadRequest(validationResult.Errors.Select(error => error.ErrorMessage));
            }

            await _activityService.AddAsync(activity);
            return Ok();
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }

    [HttpDelete("{activityId}")]
    public async Task<ActionResult> DeleteAktivity(int activityId)
    {
        try
        {
            await _activityService.RemoveAsync(activityId);
            return NoContent();
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }
}