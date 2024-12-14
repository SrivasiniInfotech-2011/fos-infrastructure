using FOS.Models.Entities;
using FOS.Repository.Interfaces;
using MediatR;

namespace FOS.Infrastructure.Queries
{
    public class GetProspectDetailsForLead
    {
        public class Query : IRequest<LeadProspectDetail>
        {
            public int? CompanyId { get; }
            public int? UserId { get; }
            public string? MobileNumber { get; }
            public string? AadharNumber { get; }
            public string? PanNumber { get; }
            public Query(int? userId, int? companyId, string mobileNumber, string aadharNumber, string panNumber)
            {
                UserId = userId;
                CompanyId = companyId;
                AadharNumber = aadharNumber;
                MobileNumber = mobileNumber;
                PanNumber = panNumber;
            }
        }

        public class Handler(ILeadsRepository leadsRepository) : IRequestHandler<Query, LeadProspectDetail>
        {
            public Task<LeadProspectDetail> Handle(Query request, CancellationToken cancellationToken) =>
                Task.Run(() => leadsRepository.GetProspectDetailsForLead(request.CompanyId.GetValueOrDefault(), request.UserId.GetValueOrDefault(), request.MobileNumber!, request.AadharNumber!, request.PanNumber!));
        }
    }
}
