using FOS.Models.Entities;
using FOS.Repository.Interfaces;
using MediatR;

namespace FOS.Infrastructure.Queries
{
    public class GetLeadAssetDetails
    {
        public class Query(int? userId, int? companyId, string? leadNumber, string? vehicleNumber) : IRequest<FvrAsset?>
        {
            public int? CompanyId { get; } = companyId;
            public int? UserId { get; } = userId;
            public string? LeadNumber { get; } = leadNumber;
            public string? VehicleNumber { get; } = vehicleNumber;
        }
        public class Handler(IFieldVerficationRepository repository) : IRequestHandler<Query, FvrAsset?>
        {
            public Task<FvrAsset?> Handle(Query request, CancellationToken cancellationToken) =>
                Task.Run(() => repository.GetLeadAssetDetails(request.CompanyId, request.UserId, request.LeadNumber, request.VehicleNumber));
        }
    }
}
