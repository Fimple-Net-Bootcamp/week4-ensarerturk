using FluentValidation;
using Microsoft.AspNetCore.Mvc;
using PetFriendTrackingAPI.DTO;
using PetFriendTrackingAPI.Services.Contract;

namespace PetFriendTrackingAPI.Controllers;

[ApiController]
[Route("api/v1/foods")]
public class FoodController : ControllerBase
{
    private readonly IFoodService _foodService;
    private readonly IValidator<PostFoodDTO> _validator;

    public FoodController(IFoodService foodService, IValidator<PostFoodDTO> validator)
    {
        _foodService = foodService;
        _validator = validator;
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<GetFoodDTO>>> GetAll()
    {
        try
        {
            var foods = await _foodService.GetAllAsync();
            return Ok(foods);
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }

    [HttpGet("{foodId}")]
    public async Task<ActionResult<GetFoodDTO>> GetById(int foodId)
    {
        try
        {
            var food = await _foodService.GetByIdAsync(foodId);

            if (food == null)
                return NotFound();

            return Ok(food);
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }

    [HttpPost]
    public async Task<ActionResult> Post([FromBody] PostFoodDTO food)
    {
        try
        {
            var validationResult = _validator.Validate(food);

            if (!validationResult.IsValid)
            {
                return BadRequest(validationResult.Errors.Select(error => error.ErrorMessage));
            }

            await _foodService.AddAsync(food);
            return Ok();
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }

    [HttpPost("giveFoods/{petAnimalId}")]
    public async Task<ActionResult> GiveFood(int petAnimalId, string foodName)
    {
        try
        {
            await _foodService.GiveFoodAsync(petAnimalId, foodName);
            return Ok("Your pet was successfully fed.");
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }

    [HttpPut("{foodId}")]
    public async Task<ActionResult> Put(int foodId, [FromBody] PostFoodDTO besin)
    {
        try
        {
            await _foodService.UpdateAsync(besin);
            return Ok();
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }

    [HttpDelete("{foodId}")]
    public async Task<ActionResult> DeleteBesin(int foodId)
    {
        try
        {
            await _foodService.RemoveAsync(foodId);
            return Ok();
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }
}