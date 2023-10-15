using Application.Handlers.Dogs.Commands.CreateDog;
using Application.Handlers.Dogs.Queries.GetDogs;
using Carter;
using MediatR;

namespace WebApi.Modules.Dogs
{
    public class DogsModule : CarterModule
    {
        public override void AddRoutes(IEndpointRouteBuilder app)
        {
            app.MapGet("/dogs", async (
                int? pageSize,
                int? PageNumber,
                int? limit,
                string? order,
                string? sortAttribute,
                ISender sender) =>
            {
                var query = new DogsQuery()
                {
                    PageSize = pageSize ?? 10,
                    PageNumber = PageNumber ?? 1,
                    Limit = limit ?? 1000,
                    Order = order ?? "asc",
                    SortAttribute = sortAttribute ?? "name",
                };

                var dogs = await sender.Send(query);
                return dogs;
            });

            app.MapPost("/dog", async (CreateDogCommand command, ISender sender) =>
            {
                var createdDogId = await sender.Send(command);
                return createdDogId;
            });
        }
    }
}
