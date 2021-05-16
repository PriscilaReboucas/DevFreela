using DevFreela.Application.Commands.CreateUser;
using FluentValidation;

namespace DevFreela.Application.Validators
{
    public class CreateUserInputModelValidator
        : AbstractValidator<CreateUserInputModel>
    {
        public CreateUserInputModelValidator()
        {
            RuleFor(im => im.Email)
                .NotNull()
                .WithMessage("E-mail precisa ser preenchido.")
                .NotEmpty()
                .WithMessage("E-mail precisa ser preenchido.");
        }
    }
}
