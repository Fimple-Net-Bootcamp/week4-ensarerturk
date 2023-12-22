using FluentValidation;
using PetFriendTrackingAPI.DTO;

namespace PetFriendTrackingAPI.Validators;

public class PostFoodDTOValidator : AbstractValidator<PostFoodDTO>
{
    public PostFoodDTOValidator()
    {
        RuleFor(dto => dto.Name)
            .NotEmpty().WithMessage("Name cannot be empty.")
            .MaximumLength(100).WithMessage("Name must be at most 100 characters.")
            .Matches("^[a-zA-Z0-9 ]*$").WithMessage("Name can only contain letters, numbers, and spaces.");

        RuleFor(dto => dto.Type)
            .NotEmpty().WithMessage("Type cannot be empty.")
            .MaximumLength(50).WithMessage("Type must be at most 50 characters.")
            .Matches("^[a-zA-Z0-9 ]*$").WithMessage("Type can only contain letters, numbers, and spaces.");

        RuleFor(dto => dto.Kalori)
            .NotEmpty().WithMessage("Calories cannot be empty.")
            .GreaterThan(0).WithMessage("Calories must be greater than 0.");

        RuleFor(dto => dto.Protein)
            .NotEmpty().WithMessage("Protein cannot be empty.")
            .GreaterThan(0).WithMessage("Protein must be greater than 0.");

        RuleFor(dto => dto.Oil)
            .NotEmpty().WithMessage("Oil cannot be empty.")
            .GreaterThan(0).WithMessage("Oil must be greater than 0.");

        RuleFor(dto => dto.Carbohydrate)
            .NotEmpty().WithMessage("Carbohydrate cannot be empty.")
            .GreaterThan(0).WithMessage("Carbohydrate must be greater than 0.");
    }
}