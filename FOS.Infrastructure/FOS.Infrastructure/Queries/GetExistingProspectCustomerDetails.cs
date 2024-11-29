using FOS.Models.Entities;
using FOS.Repository.Interfaces;
using MediatR;

namespace FOS.Infrastructure.Queries
{
    public class GetExistingProspectCustomerDetails
    {
        public class Query : IRequest<Prospect>
        {
            public int? CompanyId { get; set; }
            public int? UserId { get; set; }
            public string MobileNumber { get; set; }
            public string AadharNumber { get; set; }
            public string PanNumber { get; set; }
            public int? ProspectId { get; set; }
            public Query(int? userId, int? companyId, int? prospectId, string mobileNumber, string aadharNumber, string panNumber)
            {
                UserId = userId;
                CompanyId = companyId;
                ProspectId = prospectId;
                MobileNumber = mobileNumber;
                AadharNumber = aadharNumber;
                PanNumber = panNumber;
            }
        }

        public class Handler(IProspectRepository repository) : IRequestHandler<Query, Prospect>
        {
            public async Task<Prospect> Handle(Query request, CancellationToken cancellationToken) =>
                await repository.GetExistingProspectCustomerDetails(request.CompanyId, request.UserId, request.MobileNumber, request.AadharNumber, request.PanNumber, request.ProspectId);
        }
    }
}
