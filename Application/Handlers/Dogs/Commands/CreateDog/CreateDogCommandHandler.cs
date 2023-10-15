using Application.Common.Interfaces;
using Domain.Entities;
using MediatR;

namespace Application.Handlers.Dogs.Commands.CreateDog
{
    public class CreateDogCommandHandler : IRequestHandler<CreateDogCommand, int>
    {
        private readonly IUnitOfWork _unitOfWork;
        public CreateDogCommandHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public async Task<int> Handle(CreateDogCommand request, CancellationToken cancellationToken)
        {
            var dog = new Dog()
            {
                Name = request.Name,
                Color = request.Color,
                TailLength = request.TailLength,
                Weight = request.Weight,
            };

            await _unitOfWork.Dogs.Add(dog);

            await _unitOfWork.SaveChangesAsync(cancellationToken);

            return dog.Id;
        }
    }
}
