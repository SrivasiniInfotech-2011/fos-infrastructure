using FOS.Models.Entities;
using FOS.Repository.Interfaces;
using MediatR;

namespace FOS.Infrastructure.Queries
{
    public class GetLeadDetails
    {
        public class Query(int companyId, int userId, int leadId, string vehicleNumber, string leadNumber) : IRequest<Lead>
        {
            public int CompanyId { get; set; } = companyId;
            public int UserId { get; set; } = userId;
            public int LeadId { get; set; } = leadId;
            public string VehicleNumber { get; set; } = vehicleNumber;
            public string LeadNumber { get; set; } = leadNumber;
        }

        public class Handler(ILeadsRepository leadsRepository) : IRequestHandler<Query, Lead>
        {
            public Task<Lead> Handle(Query request, CancellationToken cancellationToken) => 
                Task.Run(() => leadsRepository.GetLeadDetails(request.CompanyId, request.UserId, request.LeadId, request.VehicleNumber, request.LeadNumber));
        }
    }
}
