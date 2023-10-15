using MediatR;

namespace Application.Handlers.Ping.Queries
{
    public class PingQueryHandler : IRequestHandler<PingQuery, string>
    {
        public Task<string> Handle(PingQuery request, CancellationToken cancellationToken)
        {
            return Task.FromResult("Dogshouseservice.Version1.0.1");
        }
    }
}
