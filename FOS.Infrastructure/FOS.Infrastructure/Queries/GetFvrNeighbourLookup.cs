﻿using FOS.Models.Entities;
using FOS.Repository.Interfaces;
using MediatR;

namespace FOS.Infrastructure.Queries
{
    public class GetFvrNeighbourLookup
    {
        public class Query : IRequest<IEnumerable<Lookup>?>
        {
            public int? CompanyId { get; }
            public int? UserId { get; }
            public Query(int? userId, int? companyId)
            {
                UserId = userId;
                CompanyId = companyId;
            }
        }
        public class Handler(IFieldVerficationRepository repository) : IRequestHandler<Query, IEnumerable<Lookup>?>
        {
            public Task<IEnumerable<Lookup>?> Handle(Query request, CancellationToken cancellationToken) =>
                Task.Run(() => repository.GetFvrNeighbourLookup(request.CompanyId, request.UserId));
        }
    }
}
