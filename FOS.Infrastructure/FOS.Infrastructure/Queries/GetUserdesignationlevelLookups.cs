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
    public class GetUserDesignationlevelLookups
    {

        public class Query : IRequest<List<Lookup>>
        {
            public int? CompanyId { get; }
           


            public Query( int? companyId)
            {
               
                CompanyId = companyId;

            }

        }

        public class Handler : IRequestHandler<Query, List<Lookup>>
        {
            private readonly IUsermanagementRepository _usermanagementRepository;

            public Handler(IUsermanagementRepository repository)
            {
                _usermanagementRepository = repository;
            }
            public async Task<List<Lookup>> Handle(Query request, CancellationToken cancellationToken)
            {
                return await _usermanagementRepository.GetUserdesignationlevelLookup(request.CompanyId);
            }
        }
    }
}
