using System;
using System.Collections.Generic;
using System.Linq;
using System.IO;
using System.Text;
using System.Threading.Tasks;
using organizadorFamilia.Models;


namespace organizadorFamilia.Services
{
    public class CsvService
    {
        public List<FileDetail> ReadCsv(string filePath)
        {
            var fileDetails = new List<FileDetail>();

            var lines = File.ReadAllLines(filePath);
            foreach (var line in lines.Skip(1)) // Assuming the first line is header
            {
                var columns = line.Split(';');

                var fileDetail = new FileDetail
                {
                    FileName = columns[1],  // Adjust index based on CSV structure
                    Equipo = columns[5],
                    Folder = columns[6],    // Adjust index based on CSV structure
                    SubFolder = columns[7]  // Adjust index based on CSV structure
                };

                fileDetails.Add(fileDetail);
            }

            return fileDetails;
        }
    }
}
