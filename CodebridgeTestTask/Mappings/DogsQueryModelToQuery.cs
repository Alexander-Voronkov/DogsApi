using Application.Handlers.Dogs.Queries.GetDogs;
using Riok.Mapperly.Abstractions;
using WebApi.Modules.Dogs;

namespace Application.Common.Mappings
{
    [Mapper]
    public partial class Mapper
    {
        public partial DogsQuery MapFromDogsQueryModel(DogsQueryRequest model);
    }
}
