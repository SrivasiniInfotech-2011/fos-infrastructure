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
    public class GetFieldExecutives
    {
        public class Query : IRequest<IEnumerable<FieldExecutive>?>
        {
            public int? CompanyId { get; }
            public int? UserId { get; }
            public string? Prefix { get; }
            public Query(int? userId, int? companyId,string prefix)
            {
                UserId = userId;
                CompanyId = companyId;
                Prefix = prefix;
            }
        }
        public class Handler(IProspectRepository repository) : IRequestHandler<Query, IEnumerable<FieldExecutive>?>
        {
            public Task<IEnumerable<FieldExecutive>?> Handle(Query request, CancellationToken cancellationToken) =>
                Task.Run(() => repository.GetFieldExecutives(request.CompanyId.GetValueOrDefault(), request.UserId.GetValueOrDefault(),request.Prefix!));
        }
    }
}
