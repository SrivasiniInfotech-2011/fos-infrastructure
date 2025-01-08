namespace FOS.Infrastructure.Services.FileServer
{
    public interface IFileServerService
    {
        /// <summary>
        /// Uploads File to a File Server
        /// </summary>
        /// <param name="fileName">File Name.</param>
        /// <param name="fileContent"> File Content.</param>
        /// <returns>value of type <see cref="string>"/></returns>
        public string UploadFile(string fileName, string fileContent);
    }
}
