using FOS.Infrastructure.Services.FileServer;
using FOS.Models.Requests;
using FOS.Repository.Interfaces;
using MediatR;

namespace FOS.Infrastructure.Commands
{
    public class CreateProspectCommand
    {
        public class Command : IRequest<int>
        {
            public CreateProspectRequestModel ProspectCommand { get; set; }
            public Command(CreateProspectRequestModel newProspect)
            {
                ProspectCommand = newProspect;
            }
        }

        public class Handler(IProspectRepository repository, IFileServerService fileServerService) : IRequestHandler<Command, int>
        {
            public async Task<int> Handle(Command request, CancellationToken cancellationToken)
            {
                int errorCode = 0;
                if (!request.ProspectCommand.Prospect.AadharImagePath.Contains("http"))
                {
                    var aadharFileServerUrl = fileServerService.UploadFile($"PROSPECTS/{request.ProspectCommand.Prospect.AadharImagePath}", request.ProspectCommand.Prospect.AadharImageContent);
                    request.ProspectCommand.Prospect.AadharImagePath = aadharFileServerUrl;
                }
                if (!request.ProspectCommand.Prospect.PanNumberImagePath.Contains("http"))
                {
                    var panFileServerUrl = fileServerService.UploadFile($"PROSPECTS/{request.ProspectCommand.Prospect.PanNumberImagePath}", request.ProspectCommand.Prospect.PanNumberImageContent);
                    request.ProspectCommand.Prospect.PanNumberImagePath = panFileServerUrl;
                }
                if (!request.ProspectCommand.Prospect.ProspectImagePath.Contains("http"))
                {
                    var guarantorFileServerUrl = fileServerService.UploadFile($"PROSPECTS/{request.ProspectCommand.Prospect.ProspectImagePath}", request.ProspectCommand.Prospect.ProspectImageContent);
                    request.ProspectCommand.Prospect.ProspectImagePath = guarantorFileServerUrl;
                }
                return await repository.InsertProspectDetails(request.ProspectCommand.Prospect.CompanyId.GetValueOrDefault(), request.ProspectCommand.Prospect.LocationId.GetValueOrDefault(),
                    request.ProspectCommand.Prospect.ProspectTypeId.GetValueOrDefault(), request.ProspectCommand.Prospect.CustomerId.GetValueOrDefault(), request.ProspectCommand.Prospect.CustomerCode,
                    request.ProspectCommand.Prospect.GenderId, request.ProspectCommand.Prospect.ProspectName, request.ProspectCommand.Prospect.ProspectDate,
                    request.ProspectCommand.Prospect.DateofBirth, request.ProspectCommand.Prospect.MobileNumber, request.ProspectCommand.Prospect.AlternateMobileNumber,
                    request.ProspectCommand.Prospect.Email, request.ProspectCommand.Prospect.Website, request.ProspectCommand.Prospect.CommunicationAddress?.AddressLine1,
                    request.ProspectCommand.Prospect.CommunicationAddress.AddressLine2, request.ProspectCommand.Prospect.CommunicationAddress?.Landmark, request.ProspectCommand.Prospect.CommunicationAddress?.City,
                    request.ProspectCommand.Prospect.CommunicationAddress.StateId, request.ProspectCommand.Prospect.CommunicationAddress?.CountryId, request.ProspectCommand.Prospect.CommunicationAddress?.Pincode,
                    request.ProspectCommand.Prospect.PermanentAddress?.AddressLine1, request.ProspectCommand.Prospect.PermanentAddress?.AddressLine2, request.ProspectCommand.Prospect.PermanentAddress?.Landmark, request.ProspectCommand.Prospect.PermanentAddress?.City,
                    request.ProspectCommand.Prospect.PermanentAddress?.StateId, request.ProspectCommand.Prospect.PermanentAddress?.CountryId, request.ProspectCommand.Prospect.PermanentAddress?.Pincode, request.ProspectCommand.Prospect.AadharNumber,
                    request.ProspectCommand.Prospect.AadharImagePath, request.ProspectCommand.Prospect.PanNumber, request.ProspectCommand.Prospect.PanNumberImagePath,
                    request.ProspectCommand.Prospect.ProspectImagePath, request.ProspectCommand.UserId, request.ProspectCommand.Prospect.ProspectId, request.ProspectCommand.Prospect.ProspectCode,
                    errorCode);
            }
        }
    }
}
