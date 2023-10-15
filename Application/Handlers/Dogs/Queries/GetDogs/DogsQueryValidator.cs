using Domain.Entities;
using FluentValidation;

namespace Application.Handlers.Dogs.Queries.GetDogs
{
    public class DogsQueryValidator : AbstractValidator<DogsQuery>
    {
        public DogsQueryValidator()
        {
            RuleFor(x => x.PageNumber)
                .GreaterThan(0)
                .WithMessage("Invalid argument: Page number.");

            RuleFor(x => x.PageSize)
                .GreaterThan(0)
                .WithMessage("Invalid argument: Page size.");

            RuleFor(x => x.Limit)
                .GreaterThan(0)
                .WithMessage("Invalid argument: Limit.");

            RuleFor(x => x.SortAttribute)
                .Must(x => typeof(Dog).GetProperties().FirstOrDefault(q => q.Name.ToLower() == x.ToLower()) != null)
                .WithMessage("Invalid argument: Sort attribute.");

            RuleFor(x => x.Order)
                .Must(x => x?.ToLower() == "asc" || x?.ToLower() == "desc")
                .WithMessage("Invalid argument: Order.");
        }
    }
}
