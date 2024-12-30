using FOS.Models.Entities;
using FOS.Repository.Interfaces;
using MediatR;

namespace FOS.Infrastructure.Queries
{
    public class GetLeadHirerDetails
    {
        public class Query(int? userId, int? companyId,string? mode, string? leadNumber, string? vehicleNumber) : IRequest<FvrDetail?>
        {
            public int? CompanyId { get; } = companyId;
            public int? UserId { get; } = userId;
            public string? Mode { get; } = mode;
            public string? LeadNumber { get; } = leadNumber;
            public string? VehicleNumber { get; } = vehicleNumber;
        }
        public class Handler(IFieldVerficationRepository repository) : IRequestHandler<Query, FvrDetail?>
        {
            public Task<FvrDetail?> Handle(Query request, CancellationToken cancellationToken) =>
                Task.Run(() => repository.GetLeadHirerDetails(request.CompanyId, request.UserId,request.Mode, request.LeadNumber, request.VehicleNumber));
        }
    }
}
