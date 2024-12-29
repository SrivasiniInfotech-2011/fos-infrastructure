using FOS.Models.Entities;
using FOS.Repository.Interfaces;
using MediatR;

namespace FOS.Infrastructure.Queries
{
    public class GetFvrNeighbourHoodDetails
    {
        public class Query(int? userId, int? companyId, int? fieldVerificationId, int? leadId) : IRequest<FvrDetail?>
        {
            public int? CompanyId { get; } = companyId;
            public int? UserId { get; } = userId;
            public int? FieldVerificationId { get; }=fieldVerificationId;
            public int? LeadId { get; }=leadId;
        }
        public class Handler(IFieldVerficationRepository repository) : IRequestHandler<Query, FvrDetail?>
        {
            public Task<FvrDetail?> Handle(Query request, CancellationToken cancellationToken) =>
                Task.Run(() => repository.GetFvrNeighbourHoodDetails(request.CompanyId, request.UserId, request.LeadId,request.FieldVerificationId));
        }
    }
}
