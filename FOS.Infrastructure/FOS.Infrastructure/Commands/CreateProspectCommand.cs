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

        public class Handler(IProspectRepository repository) : IRequestHandler<Command, int>
        {
            public Task<int> Handle(Command request, CancellationToken cancellationToken)
            {
                int errorCode = 0;
                return repository.InsertProspectDetails(request.ProspectCommand.Prospect.CompanyId.GetValueOrDefault(), request.ProspectCommand.Prospect.LocationId.GetValueOrDefault(),
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
