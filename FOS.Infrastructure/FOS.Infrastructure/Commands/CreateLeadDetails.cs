using FOS.Models.Entities;
using FOS.Repository.Interfaces;
using MediatR;

namespace FOS.Infrastructure.Commands
{
    public class CreateLeadDetails
    {
        public class Command(int userId, int companyId, int locationId, LeadHeader leadHeader) : IRequest<LeadHeader>
        {
            public int UserId { get; set; } = userId;
            public int CompanyId { get; set; } = companyId;
            public int LocationId { get; set; } = locationId;
            public LeadHeader LeadHeader { get; set; } = leadHeader;
        }

        public class Handler(ILeadsRepository leadsRepository) : IRequestHandler<Command, LeadHeader>
        {
            public async Task<LeadHeader> Handle(Command request, CancellationToken cancellationToken) =>
                await leadsRepository.InsertLeadDetails(request.CompanyId,request.UserId,request.LocationId,request.LeadHeader);
        }
    }
}
