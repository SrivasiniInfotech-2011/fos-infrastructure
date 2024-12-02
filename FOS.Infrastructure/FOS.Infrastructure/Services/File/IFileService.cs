namespace FOS.Infrastructure.Services.File
{
    public interface IFileService<T> where T : class
    {
        /// <summary>
        /// Generate a File with the DataTable.
        /// </summary>
        /// <param name="data">Data Table containing the Data to be Transformed</param>
        /// <param name="columnNames">Column Names to appear on the Report.</param>
        /// <returns>Returns the data in the form of <see cref="byte[]"/></returns>
        public byte[] GenerateFile(List<T> data, Dictionary<string, string> columnNames);
    }
}
