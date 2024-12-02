using FOS.Models.Constants;
using FOS.Repository.Interfaces;
using MediatR;
using static FOS.Models.Constants.Constants;

namespace FOS.Infrastructure.Queries
{
    public class DownloadProspectReport
    {
        public class Query(string fileOutput) : IRequest<Stream>
        {
            public FileOutput FileOutput { get; set; } = (FileOutput)Enum.Parse(typeof(FileOutput), fileOutput, true);
        }
        public class Handler(IProspectRepository prospectRepository, FileServiceResolver fileServiceResolver) : IRequestHandler<Query, Stream>
        {
            public async Task<Stream> Handle(Query request, CancellationToken cancellationToken)
            {
                var fileService = fileServiceResolver(request.FileOutput);
                var prospectDataForExport = await prospectRepository.GetProspectDataForExport();
                var filebytes = fileService.GenerateFile(prospectDataForExport, Constants.ProspectDataColumnNames);
                return new MemoryStream(filebytes);
            }
        }
    }
}
