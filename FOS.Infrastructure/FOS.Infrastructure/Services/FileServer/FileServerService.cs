using FOS.Models.Configurations;
using Microsoft.Extensions.Logging;
using System.Net;

namespace FOS.Infrastructure.Services.FileServer
{
    public class FileServerService(FileServerConfiguration configuration, ILogger<FileServerService> logger) : IFileServerService
    {
        /// <summary>
        /// Uploads File to a File Server
        /// </summary>
        /// <param name="fileName">File Name.</param>
        /// <param name="fileStream"> File Stream.</param>
        /// <returns>value of type <see cref="FtpWebResponse>"/></returns>
        public async Task<string> UploadFile(string fileName, byte[] fileBytes)
        {
            var filePath = $@"{configuration.CmsFilePath}\{fileName}";

            try
            {
                logger.LogInformation($"Writing to File Path:{filePath}");
                var directory = Path.GetDirectoryName(filePath);
                Directory.CreateDirectory(directory);
                using (var fileStream = new FileStream(filePath, FileMode.OpenOrCreate, FileAccess.Write))
                {
                    await fileStream.WriteAsync(fileBytes);
                    await fileStream.FlushAsync();
                    fileStream.Close();
                }
                logger.LogInformation($"Writing to File Path:{filePath} has been successfully completed.");
                return @$"{configuration.CmsUrl}/{fileName}";
            }
            catch (Exception ex)
            {
                logger.LogInformation($"An Exception occured while writing to File Path: {filePath}. Exception Message:{ex.Message}. Stack Trtace:{ex.StackTrace}");
                throw;
            }
        }
    }
}
