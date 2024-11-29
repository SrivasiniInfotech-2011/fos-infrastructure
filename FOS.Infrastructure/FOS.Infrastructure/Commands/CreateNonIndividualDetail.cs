using FOS.Models.Entities;
using FOS.Repository.Interfaces;
using MediatR;

namespace FOS.Infrastructure.Commands
{
    public class CreateNonIndividualDetail
    {
        public class Command(int userId, int leadId, LeadNonIndividualDetail leadNonIndividualDetails) : IRequest<int>
        {
            public int UserId { get; set; } = userId;
            public int LeadId { get; set; } = leadId;
            public LeadNonIndividualDetail LeadNonIndividualDetails { get; set; } = leadNonIndividualDetails;
        }

        public class Handler(ILeadsRepository leadsRepository) : IRequestHandler<Command, int>
        {
            public async Task<int> Handle(Command request, CancellationToken cancellationToken) =>
                await leadsRepository.InsertLeadNonIndividual(request.UserId, request.LeadId, request.LeadNonIndividualDetails);
        }
    }
}
