using FOS.Infrastructure.Services.File;
using FOS.Models.Entities;
using static FOS.Models.Constants.Constants;

namespace FOS.Infrastructure
{
    public delegate IFileService<ProspectExportData> FileServiceResolver(FileOutput key);

    public class Startup
    {
    }
}
