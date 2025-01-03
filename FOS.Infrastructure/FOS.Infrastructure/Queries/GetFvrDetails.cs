using FOS.Models.Entities;
using FOS.Repository.Interfaces;
using MediatR;

namespace FOS.Infrastructure.Queries
{
    public class GetFvrDetails
    {
        public class Query(int? userId, int? companyId, int? leadId, int? personType) : IRequest<FvrDetail?>
        {
            public int? CompanyId { get; } = companyId;
            public int? UserId { get; } = userId;
            public int? LeadId { get; } = leadId;
            public int? PersonType { get; } = personType;
        }

        public class Handler(IFieldVerficationRepository repository) : IRequestHandler<Query, FvrDetail?>
        {
            public Task<FvrDetail?> Handle(Query request, CancellationToken cancellationToken)
            {
                return Task.Run(() => repository.GetFvrDetails(request.CompanyId, request.UserId, request.LeadId, request.PersonType));
            }
        }
    }
}
