using BankManagementSystem.DTOs.ClientDTOs;
using FluentValidation;

namespace BankManagementSystem.Validations;

public class CreateClientValidator : AbstractValidator<CreateClient>
{
    public CreateClientValidator()
    {
        RuleFor(c => c.FirstName)
            .NotEmpty()
            .MinimumLength(5)
            .MaximumLength(20);
        
        RuleFor(c => c.Email)
            .NotEmpty()
            .MinimumLength(5)
            .EmailAddress();

        RuleFor(c => c.Age)
            .GreaterThan(17)
            .LessThan(100);
    }
}