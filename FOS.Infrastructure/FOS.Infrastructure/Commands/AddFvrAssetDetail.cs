using FOS.Models.Entities;
using FOS.Repository.Interfaces;
using MediatR;

namespace FOS.Infrastructure.Commands
{
    public class AddFvrAssetDetail
    {
        public class Command(int? companyId, int? userId, int? leadId, FvrAssetDetail? assetDetail) : IRequest<int>
        {
            public int? CompanyId { get; set; } = companyId;
            public int? UserId { get; set; } = userId;
            public int? LeadId { get; set; } = leadId;
            public FvrAssetDetail? AssetDetail { get; set; } = assetDetail;
        }

        public class Handler(IFieldVerficationRepository fvrRepository) : IRequestHandler<Command, int>
        {
            public async Task<int> Handle(Command request, CancellationToken cancellationToken) =>
                 await fvrRepository.AddFvrAssetDetail(request.CompanyId, request.UserId, request.LeadId, request.AssetDetail);

        }
    }
}
