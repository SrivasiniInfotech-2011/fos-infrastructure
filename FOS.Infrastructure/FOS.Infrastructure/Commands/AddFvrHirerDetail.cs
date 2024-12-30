using FOS.Models.Entities;
using FOS.Repository.Interfaces;
using MediatR;

namespace FOS.Infrastructure.Commands
{
    public class AddFvrHirerDetail
    {
        public class Command(int? companyId,  int? leadId, FvrDetail? fvrDetail) : IRequest<int>
        {
            public int? CompanyId { get; set; } = companyId;
            public int? LeadId { get; set; } = leadId;
            public FvrDetail? FvrDetail { get; set; } = fvrDetail;
        }

        public class Handler(IFieldVerficationRepository fvrRepository) : IRequestHandler<Command, int>
        {
            public async Task<int> Handle(Command request, CancellationToken cancellationToken) =>
                 await fvrRepository.AddFvrHirerDetail(request.CompanyId, request.LeadId, request.FvrDetail);

        }
    }
}
