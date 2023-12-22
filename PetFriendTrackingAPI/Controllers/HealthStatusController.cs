using FluentValidation;
using Microsoft.AspNetCore.Mvc;
using PetFriendTrackingAPI.DTO;
using PetFriendTrackingAPI.Services.Contract;

namespace PetFriendTrackingAPI.Controllers;

[ApiController]
[Route("api/v1/healthstatus")]
public class HealthStatusController : ControllerBase
{
    private readonly IHealthStatusService _healthStatusService;
    private readonly IValidator<PostHealthStatusDTO> _postValidator;
    private readonly IValidator<PatchHealthStatusDTO> _patchValidator;

    public HealthStatusController(IHealthStatusService healthStatusService,
        IValidator<PostHealthStatusDTO> postValidator
        , IValidator<PatchHealthStatusDTO> patchValidator)
    {
        _healthStatusService = healthStatusService;
        _postValidator = postValidator;
        _patchValidator = patchValidator;
    }

    [HttpGet("{petAnimalId}")]
    public async Task<ActionResult<GetHealthStatusDTO>> Get(int petAnimalId)
    {
        try
        {
            var healthStatus = await _healthStatusService.GetByIdAsync(petAnimalId);

            if (healthStatus == null)
                return NotFound();

            return Ok(healthStatus);
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }

    [HttpPost]
    public async Task<ActionResult> Add([FromBody] PostHealthStatusDTO healthStatusDto)
    {
        try
        {
            var validationResult = _postValidator.Validate(healthStatusDto);

            if (!validationResult.IsValid)
            {
                return BadRequest(validationResult.Errors.Select(error => error.ErrorMessage));
            }

            await _healthStatusService.AdduAsync(healthStatusDto);
            return Ok("Created");
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }

    [HttpPatch("{petAnimalId}")]
    public async Task<ActionResult> Patch(int petAnimalId, [FromBody] PatchHealthStatusDTO healthStatus)
    {
        try
        {
            var validationResult = _patchValidator.Validate(healthStatus);

            if (!validationResult.IsValid)
            {
                return BadRequest(validationResult.Errors.Select(error => error.ErrorMessage));
            }

            await _healthStatusService.UpdateAsync(petAnimalId, healthStatus);
            return Ok("Updated.");
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }
}