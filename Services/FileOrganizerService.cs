using organizadorFamilia.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace organizadorFamilia.Services
{
    public class FileOrganizerService
    {
        private ProgressBar _progressBar;

        public FileOrganizerService(ProgressBar progressBar)
        {
            _progressBar = progressBar;
        }

        public static string FindMatchingFolder(string baseDir, string normalizedFolderName)
        {
            var directories = Directory.GetDirectories(baseDir, "*", SearchOption.AllDirectories);

            // Buscar carpeta que coincida con la ruta normalizada
            foreach (var directory in directories)
            {
                // Normaliza el nombre de la carpeta y compara
                if (Path.GetFileName(directory).NormalizePath() == normalizedFolderName)
                {
                    return directory;
                }
            }

            return null;
        }

        public void OrganizeFiles(List<FileDetail> fileDetails, string sourceDir, string destDir)
        {
            // Obtener todos los archivos en el directorio de origen
            var sourceFiles = Directory.GetFiles(sourceDir);

            _progressBar.Invoke((Action)(() =>
            {
                _progressBar.Maximum = sourceFiles.Length;
                _progressBar.Value = 0;
                _progressBar.Style = ProgressBarStyle.Continuous;
            }));

            // Iterar sobre cada archivo en el directorio de origen
            foreach (var sourceFilePath in sourceFiles)
            {
                string fileName = Path.GetFileName(sourceFilePath);

                // Buscar en el CSV si el archivo está listado
                var matchingFileDetail = fileDetails.FirstOrDefault(fd => fileName.Contains(fd.FileName));

                if (matchingFileDetail != null)
                {
                    string normalizedEquip = (matchingFileDetail.Equipo).NormalizePath();
                    string normalizedFolder = (matchingFileDetail.Folder).NormalizePath();
                    string normalizedSubFolder = (matchingFileDetail.SubFolder).NormalizePath();

                    string destEquipPath = FindMatchingFolder(destDir, normalizedEquip);
                    if (destEquipPath != null)
                    {
                        // Encontrar carpeta de destino que coincida con la ruta normalizada
                        string destFolderPath = FindMatchingFolder(destEquipPath, normalizedFolder);
                        if (destFolderPath != null)
                        {
                            destFolderPath = FindMatchingFolder(destFolderPath, normalizedSubFolder);

                            // Verificar si la carpeta de destino existe
                            if (Directory.Exists(destFolderPath))
                            {
                                string destFilePath = Path.Combine(destFolderPath, fileName);
                                File.Copy(sourceFilePath, destFilePath, true);

                                _progressBar.Invoke((Action)(() =>
                                {
                                    _progressBar.Value++;
                                }));
                            }
                            else
                            {
                                // Reportar error si la carpeta de destino no existe
                                LoggerService.Log($"Error: La carpeta destino {destFolderPath} no existe para el archivo {fileName}.");
                            }
                        }
                        else
                        {
                            // Reportar error si la carpeta de destino no existe
                            LoggerService.Log($"Error: La carpeta destino {normalizedFolder} no existe en {destDir} para el archivo {fileName}.");
                        }
                    }else
                    {
                        // Reportar error si la carpeta de destino no existe
                        LoggerService.Log($"Error: La carpeta destino {normalizedEquip} no existe en {destDir} para el archivo {fileName}.");
                    }
                }
                else
                {
                    // Reportar error si la carpeta de destino no existe
                    LoggerService.Log($"Error: El archivo {fileName} no está incluido en el archivo excel .");
                }
            }
            _progressBar.Value = _progressBar.Maximum;
        }
    }
}