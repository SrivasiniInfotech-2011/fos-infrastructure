using System.Net;

namespace FOS.Infrastructure.Services.FileServer
{
    public interface IFileServerService
    {
        /// <summary>
        /// Uploads File to a File Server
        /// </summary>
        /// <param name="fileName">File Name.</param>
        /// <param name="fileBytes"> File Bytes.</param>
        /// <returns>value of type <see cref="FtpWebResponse>"/></returns>
        public Task<string> UploadFile(string fileName, byte[] fileBytes);
    }
}
