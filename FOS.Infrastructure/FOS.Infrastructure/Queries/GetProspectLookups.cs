using FOS.Models.Entities;
using FOS.Repository.Interfaces;
using MediatR;

namespace FOS.Infrastructure.Queries
{
    public class GetProspectLookups
    {
        public class Query : IRequest<List<Lookup>>
        {
        }

        public class Handler(IProspectRepository repository) : IRequestHandler<Query, List<Lookup>>
        {
            public async Task<List<Lookup>> Handle(Query request, CancellationToken cancellationToken) =>
                await repository.GetProspectLookup();
        }
    }
}
