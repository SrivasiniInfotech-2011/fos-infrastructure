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
    public class GetUsertranslanderInfrastructure
    {

        public class Query : IRequest<GetUserTranslanderModel>
        {
            public int? CompanyId { get; set; }
            public int? UserId { get; set; }
            public Query(int? userId, int? companyId)
            {
                UserId = userId;
                CompanyId = companyId;

            }
        }

        public class Handler : IRequestHandler<Query, GetUserTranslanderModel>
        {
            private readonly IUsermanagementRepository _getuserrepository;

            public Handler(IUsermanagementRepository repository)
            {
                _getuserrepository = repository;
            }
            public async Task<GetUserTranslanderModel> Handle(Query request, CancellationToken cancellationToken)
            {
                return await _getuserrepository.getUsertranslander(request.CompanyId, request.UserId);
            }
        }
    }
}
