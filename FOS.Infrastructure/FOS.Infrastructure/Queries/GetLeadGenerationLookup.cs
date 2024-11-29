using FOS.Models.Entities;
using FOS.Repository.Interfaces;
using MediatR;

namespace FOS.Infrastructure.Queries
{
    public class GetLeadGenerationLookup
    {
        public class Query : IRequest<IEnumerable<Lookup>?>
        {
            public int CompanyId { get; set; }
            public int UserId { get; set; }
            public Query(int companyId, int userId)
            {
                CompanyId = companyId;
                UserId = userId;
            }
        }

        public class Handler(ILeadsRepository leadsRepository) : IRequestHandler<Query, IEnumerable<Lookup>?>
        {
            public Task<IEnumerable<Lookup>?> Handle(Query request, CancellationToken cancellationToken) =>
                Task.Run(() => leadsRepository.GetLeadGenerationLookup(request.CompanyId, request.UserId));
        }
    }
}
