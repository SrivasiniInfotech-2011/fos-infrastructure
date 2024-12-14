using FOS.Models.Entities;
using FOS.Repository.Interfaces;
using MediatR;

namespace FOS.Infrastructure.Queries
{
    public class GetBranchLocations
    {
        public class Query : IRequest<List<Location>>
        {
            public int? CompanyId { get; }
            public int? UserId { get; }
            public int? LobId { get; }
            public bool? IsActive { get; }
            public Query(int? userId, int? companyId, int? lobId, bool? isActive)
            {
                UserId = userId;
                CompanyId = companyId;
                LobId = lobId;
                IsActive = isActive;
            }
        }
        public class Handler(IProspectRepository repository) : IRequestHandler<Query, List<Location>>
        {
            public async Task<List<Location>> Handle(Query request, CancellationToken cancellationToken) =>
                await repository.GetBranchLocations(request.CompanyId, request.UserId, request.LobId, request.IsActive);
        }
    }
}
