using FluentValidation;
using RestaurantsAPI.Application.Restaurants.DTOs;


namespace RestaurantsAPI.Application.Validators
{
   public class CreateRestaurantDtoValidator : AbstractValidator<CreateRestaurantDto>
    {
        private readonly List<string> validCategories = ["Italian", "Chinese", "Mexican", "Indian", "French", "Japanese"];
    public CreateRestaurantDtoValidator()
        {
            RuleFor(dto => dto.Name)
                .NotEmpty()
                .Length(3, 50);

            RuleFor(dto => dto.Description) 
                .NotEmpty().WithMessage("Description is required");

            RuleFor(dto => dto.Category)
                .Must(category => validCategories.Contains(category))
                .WithMessage($"Category must be one of the following: {string.Join(", ", validCategories)}");

            RuleFor(dto => dto.ContactEmail)
                .EmailAddress().When(dto => !string.IsNullOrEmpty(dto.ContactEmail))
                .WithMessage("Invalid email address format");

            RuleFor(dto => dto.ContactNumber)
                .Matches(@"^\+?[1-9]\d{1,14}$").When(dto => !string.IsNullOrEmpty(dto.ContactNumber))
                .WithMessage("Invalid contact number format");

            RuleFor(dto => dto.PostalCode)
                .Matches(@"^\d{2}(-\d{3})$").When(dto => !string.IsNullOrEmpty(dto.PostalCode))
                .WithMessage("Invalid postal code format (XX-XXX)");
        }
    }
}
