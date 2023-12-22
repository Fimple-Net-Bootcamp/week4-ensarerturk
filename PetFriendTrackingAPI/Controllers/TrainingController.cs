using FluentValidation;
using Microsoft.AspNetCore.Mvc;
using PetFriendTrackingAPI.DTO;
using PetFriendTrackingAPI.Services.Contract;

namespace PetFriendTrackingAPI.Controllers;

[ApiController]
[Route("api/v1/training")]
public class TrainingController : ControllerBase
{
    private readonly ITrainingService _trainingService;
    private readonly IValidator<PostTrainingDTO> _validator;

    public TrainingController(ITrainingService trainingService, IValidator<PostTrainingDTO> validator)
    {
        _trainingService = trainingService;
        _validator = validator;
    }

    [HttpPost]
    public async Task<IActionResult> Post([FromBody] PostTrainingDTO training)
    {
        try
        {
            var validationResult = _validator.Validate(training);

            if (!validationResult.IsValid)
            {
                return BadRequest(validationResult.Errors.Select(error => error.ErrorMessage));
            }

            await _trainingService.AddTrainingAsync(training);
            return Ok();
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }

    [HttpGet("{evcilHayvanId}")]
    public async Task<ActionResult<IEnumerable<GetTrainingDTO>>> Get(int petAnimalId)
    {
        try
        {
            var trainings = await _trainingService.GetByPetAnimalIdAsync(petAnimalId);
            return Ok(trainings);
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }
}