using FOS.Models.Entities;
using FOS.Repository.Interfaces;
using MediatR;

namespace FOS.Infrastructure.Commands
{
    public class CreatetLeadGenerationHeader
    {
        public class Command(Lead lead) : IRequest<int>
        {
            public Lead Lead { get; set; } = lead;
        }

        public class Handler(ILeadsRepository leadsRepository) : IRequestHandler<Command, int>
        {
            public async Task<int> Handle(Command request, CancellationToken cancellationToken) =>
                await leadsRepository.InsertLeadGenerationHeader(request.Lead);
        }
    }
}
