using FluentValidation;
using Microsoft.AspNetCore.Mvc;
using PetFriendTrackingAPI.DTO;
using PetFriendTrackingAPI.Services.Contract;

namespace PetFriendTrackingAPI.Controllers;

[ApiController]
[Route("api/v1/petAnimals")]
public class PetAnimalController : ControllerBase
{
    private readonly IPetAnimalService _petAnimalService;
    private readonly IValidator<PostPetAnimalDTO> _validator;

    public PetAnimalController(IPetAnimalService petAnimalService, IValidator<PostPetAnimalDTO> validator)
    {
        _petAnimalService = petAnimalService;
        _validator = validator;
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<GetPetAnimalDTO>>> GetAll()
    {
        try
        {
            var petAnimals = await _petAnimalService.GetAllEAsync();
            return Ok(petAnimals);
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }

    [HttpGet("{petAnimalId}")]
    public async Task<ActionResult<GetPetAnimalDTO>> GetById(int petAnimalId)
    {
        try
        {
            var petAnimal = await _petAnimalService.GetByIdAsync(petAnimalId);

            if (petAnimal == null)
                return NotFound();

            return Ok(petAnimal);
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }

    [HttpGet("statistics/{petAnimalId}")]
    public async Task<ActionResult<GetPetStatisticsDTO>> GetStatistics(int petAnimalId)
    {
        try
        {
            var petStatistics = await _petAnimalService.GetStatisticsAsync(petAnimalId);

            if (petStatistics == null)
                return NotFound();

            return Ok(petStatistics);
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }

    [HttpPost]
    public async Task<ActionResult> Post([FromBody] PostPetAnimalDTO petAnimalDto)
    {
        try
        {
            var validationResult = _validator.Validate(petAnimalDto);

            if (!validationResult.IsValid)
            {
                return BadRequest(validationResult.Errors.Select(error => error.ErrorMessage));
            }

            await _petAnimalService.AddAsync(petAnimalDto);
            return Ok();
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }

    [HttpPut("{petAnimalId}")]
    public async Task<ActionResult> PutEvcilHayvan(int petAnimalId, [FromBody] PostPetAnimalDTO petAnimalDto)
    {
        try
        {
            await _petAnimalService.UpdatenAsync(petAnimalId, petAnimalDto);
            return Ok("Created.");
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }

    [HttpDelete("{petAnimalId}")]
    public async Task<ActionResult> Delete(int petAnimalId)
    {
        try
        {
            await _petAnimalService.RemoveAsync(petAnimalId);
            return Ok("Deleted.");
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }
}