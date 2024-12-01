using FOS.Models.Entities;
using FOS.Repository.Interfaces;
using MediatR;

namespace FOS.Infrastructure.Commands
{
    public class CreateGuarantorData
    {
        public class Command(Lead lead) : IRequest<bool>
        {
            public Lead Lead { get; set; } = lead;
        }

        public class Handler(ILeadsRepository leadsRepository) : IRequestHandler<Command, bool>
        {
            public Task<bool> Handle(Command request, CancellationToken cancellationToken) =>
                leadsRepository.InsertGuarantorData(request.Lead);
        }
    }
}
