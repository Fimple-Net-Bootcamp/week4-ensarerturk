using FluentValidation;
using PetFriendTrackingAPI.DTO;

namespace PetFriendTrackingAPI.Validators;

public class PostHealthStatusDTOValidator : AbstractValidator<PostHealthStatusDTO>
{
    public PostHealthStatusDTOValidator()
    {
        RuleFor(dto => dto.Description)
            .NotEmpty().WithMessage("Description cannot be empty.")
            .MaximumLength(255).WithMessage("Description must be at most 255 characters.");

        RuleFor(dto => dto.Date)
            .NotEmpty().WithMessage("Date cannot be empty.")
            .LessThanOrEqualTo(DateTime.UtcNow).WithMessage("Date must be greater than or equal to the current date.");

        RuleFor(dto => dto.PetAnimalId)
            .NotEmpty().WithMessage("Pet animal ID cannot be empty.");
    }
}