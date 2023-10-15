using FluentValidation;

namespace Application.Handlers.Dogs.Commands.CreateDog
{
    public class CreateDogCommandValidator : AbstractValidator<CreateDogCommand>
    {
        public CreateDogCommandValidator()
        {
            RuleFor(x => x.Name)
                .NotEmpty()
                .WithMessage("Dog`s name cannot be empty.");

            RuleFor(x => x.TailLength)
                .NotEmpty()
                .WithMessage("Invalid argument: TailLength.")
                .GreaterThan(0)
                .WithMessage("Dog`s tail length cannot be 0 or a negative number.");

            RuleFor(x => x.Weight)
               .NotEmpty()
               .WithMessage("Invalid argument: Weight.")
               .GreaterThan(0)
               .WithMessage("Dog`s weight cannot be 0 or a negative number.");

            RuleFor(x => x.Color)
                .NotEmpty()
                .WithMessage("There must be at least one color.");
        }
    }
}
