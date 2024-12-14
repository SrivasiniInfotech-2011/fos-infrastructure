using FOS.Models.Entities;
using FOS.Repository.Interfaces;
using MediatR;

namespace FOS.Infrastructure.Commands
{
    public class CreateLeadIndividualDetails
    {
        public class Command(int companyId, int userId, int leadId, LeadIndividualDetail leadIndividualDetails) : IRequest<int>
        {
            public int CompanyId { get; set; } = companyId;
            public int UserId { get; set; } = userId;
            public int LeadId { get; set; } = leadId;
            public LeadIndividualDetail LeadIndividualDetails { get; set; } = leadIndividualDetails;
        }

        public class Handler(ILeadsRepository leadsRepository) : IRequestHandler<Command, int>
        {
            public async Task<int> Handle(Command request, CancellationToken cancellationToken) =>
                await leadsRepository.InsertLeadIndividual(request.CompanyId, request.UserId, request.LeadId, request.LeadIndividualDetails);
        }
    }
}
