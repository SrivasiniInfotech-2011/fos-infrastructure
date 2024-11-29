using FOS.Models.Entities;
using FOS.Repository.Interfaces;
using MediatR;

namespace FOS.Infrastructure.Queries
{
    public class GetLeadsForTranslander
    {
        public class Query(
            int? companyId,
            int? userId,
            int? currentPage,
            int? pageSize,
            string? searchValue,
            string? vehicleNumber,
            string? leadNumber,
            string? status) : IRequest<LeadsTranslander>
        {
            public int? CompanyId { get; set; } = companyId;
            public int? UserId { get; set; } = userId;
            public string? Status { get; set; } = status;
            public string? LeadNumber { get; set; } = leadNumber;
            public string? VehicleNumber { get; set; } = vehicleNumber;
            public int? CurrentPage { get; set; } = currentPage;
            public int? PageSize { get; set; } = pageSize;
            public string? SearchValue { get; set; } = searchValue;
        }

        public class Handler(ILeadsRepository leadsRepository) : IRequestHandler<Query, LeadsTranslander>
        {
            public Task<LeadsTranslander> Handle(Query request, CancellationToken cancellationToken) =>
                Task.Run(() => leadsRepository.GetLeadsForTranslander(request.CompanyId, request.UserId, request.Status, request.LeadNumber, request.VehicleNumber, request.CurrentPage, request.PageSize, request.SearchValue));
        }
    }
}
