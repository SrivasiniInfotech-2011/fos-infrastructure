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
    public class GetUserdesignationlevelLookups
    {

        public class Query : IRequest<List<Lookup>>
        {
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
                return await _usermanagementRepository.GetUserdesignationlevelLookup();
            }
        }
    }
}
