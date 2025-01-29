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
    public class GetGlobalParameter
    {

        public class Query : IRequest<List<GlobalParameterRequest>>
        {
            public int? Company_ID { get; set; }
            public int? User_ID { get; set; }

            public Query(int? companyId, int? userId)
            {

                Company_ID = companyId;
                User_ID = userId;

            }
        }

        
        public class Handler :IRequestHandler<Query, List<GlobalParameterRequest>>
        {
            private readonly IProspectRepository _UsermanagementRepository;

            public Handler(IProspectRepository repository)
            {
                _UsermanagementRepository = repository;
            }
            public async Task<List<GlobalParameterRequest>> Handle(Query request, CancellationToken cancellationToken)
            {
                return await _UsermanagementRepository.Get_GlobalParameterRepository(request.Company_ID, request.User_ID);
            }
        }
    }
}
