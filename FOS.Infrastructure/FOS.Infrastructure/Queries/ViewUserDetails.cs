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
    public class ViewUserDetails
    {

        public class Query : IRequest<GetInsertUserDetailsModel>
        {
            public int? CompanyId { get; set; }
            public int? UserId { get; set; }
            public Query(int? userId, int? companyId)
            {
                UserId = userId;
                CompanyId = companyId;
                
            }
        }

        public class Handler : IRequestHandler<Query, GetInsertUserDetailsModel>
        {
            private readonly IUsermanagementRepository _getuserrepository;

            public Handler(IUsermanagementRepository repository)
            {
                _getuserrepository = repository;
            }
            public async Task<GetInsertUserDetailsModel> Handle(Query request, CancellationToken cancellationToken)
            {
                var response = await _getuserrepository.GetExistingUserDetails(request.CompanyId, request.UserId);
                return response.FirstOrDefault();
            }
        }
    }
}
