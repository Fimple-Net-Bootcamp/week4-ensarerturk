using FluentValidation;
using PetFriendTrackingAPI.DTO;

namespace PetFriendTrackingAPI.Validators;

public class PostPetAnimalDTOValidator : AbstractValidator<PostPetAnimalDTO>
{
    public PostPetAnimalDTOValidator()
    {
        RuleFor(dto => dto.Name)
            .NotEmpty().WithMessage("Name cannot be empty.")
            .MaximumLength(100).WithMessage("Name must be at most 100 characters.")
            .Matches("^[a-zA-Z0-9 ]*$").WithMessage("Name can only contain letters, numbers, and spaces.");

        RuleFor(dto => dto.Type)
            .NotEmpty().WithMessage("Type cannot be empty.")
            .MaximumLength(50).WithMessage("Type must be at most 50 characters.")
            .Matches("^[a-zA-Z0-9 ]*$").WithMessage("Type can only contain letters, numbers, and spaces.");

        RuleFor(dto => dto.BirthDate)
            .NotEmpty().WithMessage("Birth date cannot be empty.")
            .LessThanOrEqualTo(DateTime.UtcNow).WithMessage("Birth date must be greater than or equal to the current date.");

        RuleFor(dto => dto.UserId)
            .NotEmpty().WithMessage("User ID cannot be empty.");
    }
}
