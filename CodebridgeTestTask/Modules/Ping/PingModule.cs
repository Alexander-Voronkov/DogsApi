using Application.Handlers.Ping.Queries;
using Carter;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Modules.Ping
{
    public class PingModule : CarterModule
    {
        public override void AddRoutes(IEndpointRouteBuilder app)
        {
            app.MapGet("/ping", async ([FromServices] ISender sender) =>
            {
                var pingResult = await sender.Send(new PingQuery());
                return pingResult;
            });
        }
    }
}
