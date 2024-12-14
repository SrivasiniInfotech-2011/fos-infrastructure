using FOS.Models.Configurations;
using System.Net;

namespace FOS.Infrastructure.Services.FileServer
{
    public class FileServerService(FileServerConfiguration configuration) : IFileServerService
    {
        /// <summary>
        /// Uploads File to a File Server
        /// </summary>
        /// <param name="fileName">File Name.</param>
        /// <param name="fileStream"> File Stream.</param>
        /// <returns>value of type <see cref="FtpWebResponse>"/></returns>
        public async Task<string> UploadFile(string fileName, byte[] fileBytes)
        {
            try
            {
                // Combine the FTP URL with the remote path
                string uploadUrl = $"{configuration.Host}/documents/{fileName}";

                // Create a new FtpWebRequest object
                FtpWebRequest request = (FtpWebRequest)WebRequest.Create(uploadUrl);

                // Set the request method to UploadFile
                request.Method = WebRequestMethods.Ftp.UploadFile;

                // Provide the credentials
                request.Credentials = new NetworkCredential(configuration.Username, configuration.Password);

                // Set the request to use binary transfer mode
                request.UseBinary = true;

                // Set the ContentLength property
                request.ContentLength = fileBytes.Length;

                // Write the file contents to the request stream
                using (Stream requestStream = request.GetRequestStream())
                {
                    await requestStream.WriteAsync(fileBytes, 0, fileBytes.Length);
                }

                // Get the response from the FTP server
                using (FtpWebResponse response = (FtpWebResponse)request.GetResponse())
                {
                    return response.ResponseUri.ToString();
                }
            }
            catch (Exception ex)
            {
                throw;
            }
        }
    }
}
