using FluentValidation;
using Microsoft.AspNetCore.Mvc;
using PetFriendTrackingAPI.DTO;
using PetFriendTrackingAPI.Services.Contract;

namespace PetFriendTrackingAPI.Controllers;

[Route("api/v1/users")]
public class UserController : ControllerBase
{
    private readonly IUserService _userService;
    private readonly IValidator<PostUserDTO> _validator;

    public UserController(IUserService userService, IValidator<PostUserDTO> validator)
    {
        _userService = userService;
        _validator = validator;
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<GetUserDTO>>> GetAll()
    {
        try
        {
            var users = await _userService.GetAllAsync();
            return Ok(users);
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }

    [HttpGet("{userId}")]
    public async Task<ActionResult<GetUserDTO>> GetById(int userId)
    {
        try
        {
            var user = await _userService.GetByIdAsync(userId);

            if (user == null)
                return NotFound();

            return Ok(user);
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }

    [HttpPost]
    public async Task<ActionResult> Post([FromBody] PostUserDTO user)
    {
        try
        {
            var validationResult = _validator.Validate(user);

            if (!validationResult.IsValid)
            {
                return BadRequest(validationResult.Errors.Select(error => error.ErrorMessage));
            }

            await _userService.AddAsync(user);

            return CreatedAtAction(nameof(GetById), new { userId = user.Name }, user);
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }

    [HttpDelete("{userId}")]
    public async Task<ActionResult> Delete(int userId)
    {
        try
        {
            await _userService.RemoveAsync(userId);
            return NoContent();
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }

    [HttpGet("statistics/{kullaniciId}")]
    public async Task<ActionResult<GetPetStatisticsDTO>> GetPetStatistics(int kullaniciId)
    {
        try
        {
            var petStatistics = await _userService.GetPetStatisticsAsync(kullaniciId);
            return Ok(petStatistics);
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }
}