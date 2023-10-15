using MediatR;

namespace Application.Handlers.Dogs.Commands.CreateDog
{
    public class CreateDogCommand : IRequest<int>
    {
        public string? Name { get; set; }
        public string? Color { get; set; }
        public double? TailLength { get; set; }
        public double? Weight { get; set; }
    }
}
