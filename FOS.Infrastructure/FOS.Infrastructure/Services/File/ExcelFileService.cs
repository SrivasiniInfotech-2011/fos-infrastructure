using FOS.Models.Entities;
using OfficeOpenXml;

namespace FOS.Infrastructure.Services.File
{
    public class ExcelFileService : IFileService<ProspectExportData>
    {
        /// <summary>
        /// Generate a File with the DataTable.
        /// </summary>
        /// <param name="data">Data Table containing the Data to be Transformed</param>
        /// <param name="columnNames">Column Names to appear on the Report.</param>
        /// <returns>Returns the data in the form of <see cref="FileStream"/></returns>
        public byte[] GenerateFile(List<ProspectExportData> data, Dictionary<string, string> columnNames)
        {
            ExcelPackage.LicenseContext = LicenseContext.NonCommercial;
            using var memoryStream = new MemoryStream();
            using var package = new ExcelPackage(memoryStream);
            var worksheet = package.Workbook.Worksheets.Add("Prospects");

            // Add headers
            var i = 0;
            foreach (var column in columnNames)
            {
                worksheet.Cells[1, i + 1].Value = column.Key;
                i++;
            }

            // Add data
            var properties = typeof(ProspectExportData).GetProperties();
            for (int row = 0; row < data.Count; row++)
            {
                var col = 0;
                foreach (var column in columnNames)
                {
                    worksheet.Cells[row + 2, col + 1].Value = properties.FirstOrDefault(s => s.Name == column.Value)!.GetValue(data[row]);
                    col++;
                }
            }


            package.Save();
            memoryStream.Position = 0;
            return memoryStream.ToArray();
        }
    }
}
