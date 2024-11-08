using FluentValidation;
using FluentValidation.Internal;
using FOS.Infrastructure.Validators;
using FOS.Models.Constants;
using FOS.Models.Entities;
using FOS.Repository.Interfaces;
using MediatR;
using static FOS.Infrastructure.Commands.CreateProspectCommand;

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
        public class Handler : IRequestHandler<Query, List<Location>>
        {
            private readonly IProspectRepository _prospectRepository;

            public Handler(IProspectRepository repository)
            {
                _prospectRepository = repository;
            }
            public async Task<List<Location>> Handle(Query request, CancellationToken cancellationToken)
            {
                return await _prospectRepository.GetBranchLocations(request.CompanyId, request.UserId, request.LobId, request.IsActive);
            }
        }
    }
}
