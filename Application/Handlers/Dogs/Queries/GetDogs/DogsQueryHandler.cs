using Application.Common.Interfaces;
using Application.Common.Mappings;
using MediatR;

namespace Application.Handlers.Dogs.Queries.GetDogs
{
    public class DogsQueryHandler : IRequestHandler<DogsQuery, IEnumerable<DogDto>>
    {
        private readonly Mapper _mapper;
        private readonly IUnitOfWork _unitOfWork;

        public DogsQueryHandler(IUnitOfWork unitOfWork)
        {
            _mapper = new Mapper();
            _unitOfWork = unitOfWork;
        }

        public async Task<IEnumerable<DogDto>> Handle(DogsQuery query, CancellationToken cancellationToken)
        {
            var dogs = await _unitOfWork.Dogs.GetAll();

            if (query.SortAttribute != null)
            {
                if (query.Order == "asc")
                    dogs = dogs.OrderByProperty(query.SortAttribute, true);
                else
                    dogs = dogs.OrderByProperty(query.SortAttribute, false);
            }


            dogs = dogs
                .Skip((query.PageNumber.Value - 1) * query.PageSize.Value)
                .Take(query.PageSize.Value)
                .Take(query.Limit.Value);

            var mappedDogs = dogs.Select(x => _mapper.Map(x)).ToList();

            return mappedDogs;
        }



    }
}
