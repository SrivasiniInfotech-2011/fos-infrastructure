using FOS.Models.Entities;
using FOS.Repository.Interfaces;
using MediatR;

namespace FOS.Infrastructure.Queries
{
    public class GetLeadStatuses
    {
        public class Query : IRequest<IEnumerable<LeadStatus>>
        {

        }

        public class Handler(ILeadsRepository leadsRepository) : IRequestHandler<Query, IEnumerable<LeadStatus>>
        {
            public async Task<IEnumerable<LeadStatus>> Handle(Query request, CancellationToken cancellationToken) =>
                await leadsRepository.GetStatusesForLead();
        }
    }
}
