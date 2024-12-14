using FOS.Models.Entities;
using FOS.Repository.Interfaces;
using MediatR;

namespace FOS.Infrastructure.Queries
{
    public class GetStates
    {
        public class Query : IRequest<List<Lookup>>
        {
            public int? CompanyId { get; set; }
            public Query(int? companyId)
            {
                CompanyId = companyId;
            }
        }
        public class Handler(IProspectRepository repository) : IRequestHandler<Query, List<Lookup>>
        {
            public async Task<List<Lookup>> Handle(Query request, CancellationToken cancellationToken) =>
                await repository.GetStateLookups();
        }
    }
}
