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
    public class GetLobList
    {
        public class Query : IRequest<IEnumerable<LineOfBusiness>?>
        {
            public int? CompanyId { get; }
            public int? UserId { get; }
            public Query(int? userId, int? companyId)
            {
                UserId = userId;
                CompanyId = companyId;
            }
        }
        public class Handler(IProspectRepository repository) : IRequestHandler<Query, IEnumerable<LineOfBusiness>?>
        {
            public Task<IEnumerable<LineOfBusiness>?> Handle(Query request, CancellationToken cancellationToken) =>
                Task.Run(() => repository.GetLineofBusiness(request.CompanyId.GetValueOrDefault(), request.UserId.GetValueOrDefault()));
        }
    }
}