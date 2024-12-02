using FOS.Models.Entities;
using FOS.Repository.Interfaces;
using MediatR;
using static FOS.Models.Constants.Constants;

namespace FOS.Infrastructure.Queries
{
    public class GetDocumentCategories
    {
        public class Query : IRequest<IEnumerable<DocumentCategory>?>
        {
            public int? CompanyId { get; }
            public int? UserId { get; }
            public int? Option { get; }
            public Query(int? userId, int? companyId, int? option)
            {
                UserId = userId;
                CompanyId = companyId;
                Option = option;
            }
        }
        public class Handler(IProspectRepository repository) : IRequestHandler<Query, IEnumerable<DocumentCategory>?>
        {
            public Task<IEnumerable<DocumentCategory>?> Handle(Query request, CancellationToken cancellationToken) =>
                Task.Run(() => repository.GetDocumentCategories(request.CompanyId.GetValueOrDefault(), request.UserId.GetValueOrDefault(),request.Option.GetValueOrDefault()));
        }
    }
}
