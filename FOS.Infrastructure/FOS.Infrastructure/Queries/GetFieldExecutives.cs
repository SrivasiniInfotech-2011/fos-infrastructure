using FOS.Models.Entities;
using FOS.Repository.Interfaces;
using MediatR;

namespace FOS.Infrastructure.Queries
{
    public class GetFieldExecutives
    {
        public class Query : IRequest<IEnumerable<FieldExecutive>?>
        {
            public int? CompanyId { get; }
            public int? UserId { get; }
            public string? SearchPrefix { get; }
            public Query(int? userId, int? companyId, string searchPrefix)
            {
                UserId = userId;
                CompanyId = companyId;
                SearchPrefix = searchPrefix;
            }
        }
        public class Handler(IProspectRepository repository) : IRequestHandler<Query, IEnumerable<FieldExecutive>?>
        {
            public Task<IEnumerable<FieldExecutive>?> Handle(Query request, CancellationToken cancellationToken) =>
                Task.Run(() => repository.GetFieldExecutives(request.CompanyId.GetValueOrDefault(), request.UserId.GetValueOrDefault(), request.SearchPrefix!));
        }
    }
}
