using Application.Handlers.Dogs.Queries;
using Domain.Entities;
using Riok.Mapperly.Abstractions;

namespace Application.Common.Mappings
{
    [Mapper]
    public partial class Mapper
    {
        public partial DogDto Map(Dog _mapped);
    }
}
