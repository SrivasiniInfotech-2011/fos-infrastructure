using FOS.Models.Entities;
using FOS.Models.Requests;
using FOS.Repository.Interfaces;
using MediatR;
using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FOS.Infrastructure.Queries
{
    public class GetCompanyMaster
    {
        public class Query : IRequest<CompanyMasterRequest>
        {
            public int? CompanyId { get; set; }

            public Query(int? companyId)
            {

                CompanyId = companyId;

            }
        }




        public class Handler : IRequestHandler<Query, CompanyMasterRequest>
        {
            private readonly IProspectRepository _getuserrepository;

            public Handler(IProspectRepository repository)
            {
                _getuserrepository = repository;
            }
            public async Task<CompanyMasterRequest> Handle(Query request, CancellationToken cancellationToken)
            {
                return await _getuserrepository.Get_CompanyMasterRepository(request.CompanyId);
            }
        }

      
    }
}
