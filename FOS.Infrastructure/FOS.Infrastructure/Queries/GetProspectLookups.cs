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

        public class Handler : IRequestHandler<Query, List<Lookup>>
        {
            private readonly IProspectRepository _prospectRepository;

            public Handler(IProspectRepository repository)
            {
                _prospectRepository = repository;
            }
            public async Task<List<Lookup>> Handle(Query request, CancellationToken cancellationToken)
            {
                return await _prospectRepository.GetProspectLookup();
            }
        }
    }
}
