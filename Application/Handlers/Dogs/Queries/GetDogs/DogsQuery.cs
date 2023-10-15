using MediatR;

namespace Application.Handlers.Dogs.Queries.GetDogs
{
    public class DogsQuery : IRequest<IEnumerable<DogDto>>
    {
        public int? PageSize { get; set; } = 10;
        public int? PageNumber { get; set; } = 1;
        public int? Limit { get; set; } = 1000;
        public string? Order { get; set; } = "asc";
        public string? SortAttribute { get; set; } = "name";
    }
}
