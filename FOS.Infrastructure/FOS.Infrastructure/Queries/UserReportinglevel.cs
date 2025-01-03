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
    public class UserReportinglevel
    {


        public class Query : IRequest<List<ReportingLevel>>
        {
            public int? CompanyId { get; }
            public int? UserId { get; }
            public string? PrefixText { get; }

            public int? LOB_ID { get; }

            public int? location_ID { get; }



            public Query(int? companyId,int? userId,string? prefixText,int?  lobId, int? locationId)
            {

                CompanyId = companyId;
                UserId = userId;
                PrefixText = prefixText;
                LOB_ID = lobId;
                location_ID = locationId;

            }

        }

        public class Handler : IRequestHandler<Query, List<ReportingLevel>>
        {
            private readonly IUsermanagementRepository _usermanagementRepository;

            public Handler(IUsermanagementRepository repository)
            {
                _usermanagementRepository = repository;
            }
            public async Task<List<ReportingLevel>> Handle(Query request, CancellationToken cancellationToken)
            {
                return await _usermanagementRepository.getUserReportingLevel(request.CompanyId,request.UserId,request.PrefixText,request.LOB_ID,request.location_ID);
            }
        }
    }
}
