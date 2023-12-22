using FluentValidation;
using PetFriendTrackingAPI.DTO;

namespace PetFriendTrackingAPI.Validators;

public class PostUserDTOValidator : AbstractValidator<PostUserDTO>
{
    public PostUserDTOValidator()
    {
        RuleFor(dto => dto.Name)
            .NotEmpty().WithMessage("The name cannot be empty.")
            .MaximumLength(50).WithMessage("The name should be maximum 50 characters.")
            .Matches("^[a-zA-Z ]*$").WithMessage("The name can only contain letters.");

        RuleFor(dto => dto.Surname)
            .NotEmpty().WithMessage("The surname cannot be empty.")
            .MaximumLength(50).WithMessage("The surname should be maximum 50 characters.")
            .Matches("^[a-zA-Z ]*$").WithMessage("The surname can only contain letters.");

        RuleFor(dto => dto.Email)
            .NotEmpty().WithMessage("The email cannot be empty.")
            .EmailAddress().WithMessage("Enter a valid e-mail address.");

        RuleFor(dto => dto.Password)
            .NotEmpty().WithMessage("The password cannot be empty.")
            .MinimumLength(6).WithMessage("The password must be at least 6 characters long.");
    }
}