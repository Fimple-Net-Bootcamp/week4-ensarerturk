using FluentValidation;
using PetFriendTrackingAPI.DTO;

namespace PetFriendTrackingAPI.Validators;

public class PostActivityDTOValidator : AbstractValidator<PostActivityDTO>
{
    public PostActivityDTOValidator()
    {
        RuleFor(dto => dto.Type)
            .NotEmpty().WithMessage("Type cannot be empty.")
            .MaximumLength(50).WithMessage("Type must be at most 50 characters.")
            .Matches("^[a-zA-Z0-9 ]*$").WithMessage("Type can only contain letters, numbers, and spaces.");

        RuleFor(dto => dto.StartDate)
            .NotEmpty().WithMessage("Start date cannot be empty.")
            .LessThanOrEqualTo(DateTime.UtcNow).WithMessage("Start date must be greater than or equal to the current date.");

        RuleFor(dto => dto.EndDate)
            .NotEmpty().WithMessage("End date cannot be empty.")
            .GreaterThanOrEqualTo(dto => dto.StartDate).WithMessage("End date must be greater than or equal to the start date.");

        RuleFor(dto => dto.PetAnimalId)
            .NotEmpty().WithMessage("Pet animal ID cannot be empty.");
    }
}