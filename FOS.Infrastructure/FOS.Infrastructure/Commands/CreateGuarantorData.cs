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
                        var aadharContentBytes = Encoding.UTF8.GetBytes(guarantor.AadharImageContent);
                        var aadharFileServerUrl=await fileServerService.UploadFile($"{guarantor.GuarantorName}/{guarantor.AadharImagePath}", aadharContentBytes);
                        var panContentBytes = Encoding.UTF8.GetBytes(guarantor.PanImageContent);
                        var panFileServerUrl = await fileServerService.UploadFile($"{guarantor.GuarantorName}/{guarantor.PanImagePath}", panContentBytes);
                        var guarantorContentBytes = Encoding.UTF8.GetBytes(guarantor.GuarantorImageContent);
                        var guarantorFileServerUrl = await fileServerService.UploadFile($"{guarantor.GuarantorName}/{guarantor.GuarantorImagePath}", guarantorContentBytes);
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
