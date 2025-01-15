using organizadorFamilia.Domain;
using organizadorFamilia.Forms;
using organizadorFamilia.Models;
using organizadorFamilia.Services;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace organizadorFamilia
{
    public partial class Form1 : Form
    {
        private readonly Connection _connection = new Connection();
        private FamConnect frm;
        private BBDDService bdServ;

        public Form1()
        {
            InitializeComponent();
            string configFilePath = Path.Combine(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location), "Resources", "db_config.txt");
            frm = new FamConnect(_connection, configFilePath);
            bdServ = new BBDDService(_connection.CreateConnectionString(),progressBar);
        }
        private void btnAbrirExcel_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog openFileDialog = new OpenFileDialog())
            {
                openFileDialog.InitialDirectory = "c:\\";
                openFileDialog.Filter = "CSV Files|*.csv|Excel Files|*.xlsx;*.xls|All Files|*.*";
                openFileDialog.FilterIndex = 1;
                openFileDialog.RestoreDirectory = true;

                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    textBoxArchivoExcel.Text = openFileDialog.FileName;
                }
            }
        }

        private void btnDestino_Click(object sender, EventArgs e)
        {
            using (FolderBrowserDialog folderBrowserDialog = new FolderBrowserDialog())
            {
                if (folderBrowserDialog.ShowDialog() == DialogResult.OK)
                {
                    textBoxDestino.Text = folderBrowserDialog.SelectedPath;
                }
            }
        }

        private void btnOrigen_Click(object sender, EventArgs e)
        {
            using (FolderBrowserDialog folderBrowserDialog = new FolderBrowserDialog())
            {
                if (folderBrowserDialog.ShowDialog() == DialogResult.OK)
                {
                    textBoxOrigen.Text = folderBrowserDialog.SelectedPath;
                }
            }
        }

        private void btnProcesar_Click(object sender, EventArgs e)
        {
            string filePath = textBoxArchivoExcel.Text;
            string destDir = textBoxDestino.Text;
            string sourceDir = textBoxOrigen.Text;
            LoggerService.countErrors = 0;
            if (string.IsNullOrEmpty(filePath) || string.IsNullOrEmpty(destDir) || string.IsNullOrEmpty(sourceDir))
            {
                MessageBox.Show("Por favor, selecciona todos los archivos y directorios.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Lógica para procesar el archivo CSV y organizar los archivos
            try
            {
                List<FileDetail> fileDetails;

                if (filePath.EndsWith(".csv", StringComparison.OrdinalIgnoreCase))
                {
                    CsvService csvService = new CsvService();
                    fileDetails = csvService.ReadCsv(filePath);
                }
                else if (filePath.EndsWith(".xlsx", StringComparison.OrdinalIgnoreCase) || filePath.EndsWith(".xls", StringComparison.OrdinalIgnoreCase))
                {
                    ExcelService excelService = new ExcelService();
                    fileDetails = excelService.ReadExcel(filePath);
                }
                else
                {
                    MessageBox.Show("Formato de archivo no soportado. Selecciona un archivo CSV o Excel.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                FileOrganizerService fileOrganizerService = new FileOrganizerService(progressBar);
                fileOrganizerService.OrganizeFiles(fileDetails, sourceDir, destDir);

                if (LoggerService.HasErrors())
                {
                    MessageBox.Show("Proceso completado con errores. Revisa el archivo log.txt para más detalles.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    Process.Start("explorer.exe", LoggerService.logFilePath);
                }
                else
                {
                    MessageBox.Show("Archivos organizados con éxito.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                LoggerService.Log($"Error: {ex.Message}");
                MessageBox.Show("Error en el proceso. Revisa el archivo log.txt para más detalles.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void BtnConexion_Click(object sender, EventArgs e)
        {
            frm.ShowDialog();
        }

        private void btnVolcarBD_Click(object sender, EventArgs e)
        {
            string excelPath = textBoxArchivoExcel.Text;
            bdServ.InsertDataFromExcel(excelPath);
        }
    }
}
