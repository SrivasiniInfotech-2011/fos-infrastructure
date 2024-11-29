using FOS.Models.Entities;
using FOS.Repository.Interfaces;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FOS.Infrastructure.Queries
{
    public class UserLevelLookup
    {
        public class Query : IRequest<List<Lookup>>
        {
            public int? CompanyId { get; }
            public int? UserId { get; }


            public Query(int? userId, int? companyId)
            {
                UserId = userId;
                CompanyId = companyId;
             
            }
        }

        public class Handler : IRequestHandler<Query, List<Lookup>>
        {
            private readonly IUsermanagementRepository _UsermanagementRepository;

            public Handler(IUsermanagementRepository repository)
            {
                _UsermanagementRepository = repository;
            }
            public async Task<List<Lookup>> Handle(Query request, CancellationToken cancellationToken)
            {
                return await _UsermanagementRepository.GetUserLevelLookup(request.CompanyId, request.UserId);
            }
        }
    }
}
