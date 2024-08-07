using ClosedXML.Excel;
using organizadorFamilia.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace organizadorFamilia.Services
{
    public class ExcelService
    {
        public List<FileDetail> ReadExcel(string filePath)
        {
            var fileDetails = new List<FileDetail>();

            using (var workbook = new XLWorkbook(filePath))
            {
                var worksheet = workbook.Worksheet(1);
                var rows = worksheet.RangeUsed().RowsUsed().Skip(1); // Omitir la primera fila si es el encabezado

                foreach (var row in rows)
                {
                    var fileDetail = new FileDetail
                    {
                        FileName = row.Cell(2).GetString(),
                        Equipo = row.Cell(6).GetString(),   
                        Folder = row.Cell(7).GetString(),
                        SubFolder = row.Cell(8).GetString()
                    };

                    fileDetails.Add(fileDetail);
                }
            }

            return fileDetails;
        }
    }
}
