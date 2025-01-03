using FOS.Infrastructure.Services.FileServer;
using FOS.Models.Entities;
using FOS.Repository.Interfaces;
using MediatR;
using System.Text;

namespace FOS.Infrastructure.Commands
{
    public class CreateGuarantorData
    {
        public class Command(Lead lead) : IRequest<bool>
        {
            public Lead Lead { get; set; } = lead;
        }

        public class Handler(ILeadsRepository leadsRepository,IFileServerService fileServerService) : IRequestHandler<Command, bool>
        {
            public async Task<bool> Handle(Command request, CancellationToken cancellationToken)
            {
                foreach(var guarantor in request.Lead.Guarantors)
                {
                    if (guarantor!=null)
                    {
                        var aadharFileServerUrl=await fileServerService.UploadFile($"GUARANTORS/{guarantor.GuarantorName}/{guarantor.AadharImagePath}", guarantor.AadharImageContent);
                        var panFileServerUrl = await fileServerService.UploadFile($"GUARANTORS/{guarantor.GuarantorName}/{guarantor.PanImagePath}", guarantor.PanImageContent);
                        var guarantorFileServerUrl = await fileServerService.UploadFile($"GUARANTORS/{guarantor.GuarantorName}/{guarantor.GuarantorImagePath}", guarantor.GuarantorImageContent);
                        guarantor.AadharImagePath = aadharFileServerUrl;
                        guarantor.PanImagePath = panFileServerUrl;
                        guarantor.GuarantorImagePath = guarantorFileServerUrl;
                    }
                }
                return await leadsRepository.InsertGuarantorData(request.Lead);
            }
        }
    }
}
