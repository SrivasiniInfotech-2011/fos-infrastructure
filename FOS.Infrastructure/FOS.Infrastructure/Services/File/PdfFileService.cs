using FOS.Models.Entities;
using iText.Kernel.Geom;
using iText.Kernel.Pdf;
using iText.Layout;
using iText.Layout.Element;
using iText.Layout.Properties;

namespace FOS.Infrastructure.Services.File
{
    public class PdfFileService : IFileService<ProspectExportData>
    {
        /// <summary>
        /// Generate a File with the DataTable.
        /// </summary>
        /// <param name="data">Data Table containing the Data to be Transformed</param>
        /// <param name="columnNames">Column Names to appear on the Report.</param>
        /// <returns>Returns the data in the form of <see cref="FileStream"/></returns>
        public byte[] GenerateFile(List<ProspectExportData> data, Dictionary<string, string> columnNames)
        {
            var memoryStream = new MemoryStream();
            // Create a PDF writer to write to the MemoryStream
            using (var pdfWriter = new PdfWriter(memoryStream))
            {
                using var pdfDocument = new PdfDocument(pdfWriter);
                pdfDocument.SetDefaultPageSize(PageSize.A1);
                
                var document = new Document(pdfDocument);
                
                // Create a table
                var properties = typeof(ProspectExportData).GetProperties();
                Table table = new Table(UnitValue.CreatePercentArray(properties.Length)).UseAllAvailableWidth();

                // Add headers
                foreach (var prop in columnNames)
                {
                    table.AddHeaderCell(new Cell().Add(new Paragraph(prop.Key)));
                }
               
                // Add data rows
                foreach (var item in data)
                {
                    foreach (var columnName in columnNames)
                    {
                        var value = properties.FirstOrDefault(s => s.Name == columnName.Value)!
                                              .GetValue(item)?.ToString() ?? string.Empty;
                        table.AddCell(new Cell().Add(new Paragraph(value)));

                    }
                }

                document.Add(table);
                document.Close();
                return memoryStream.ToArray();
            }
        }
    }
}
