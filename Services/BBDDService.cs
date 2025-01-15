using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ClosedXML.Excel;
using Npgsql;

namespace organizadorFamilia.Services
{
    public class BBDDService
    {
        private readonly string _connectionString;
        private ProgressBar _progressBar;
        private readonly string _logFilePath = "BBDDLog.txt";

        public BBDDService(string connectionString, ProgressBar progressBar)
        {
            _connectionString = connectionString;
            _progressBar = progressBar;
        }

        public void InsertDataFromExcel(string excelFilePath)
        {
            if (!File.Exists(excelFilePath))
            {
                MessageBox.Show("El archivo Excel no existe en la ruta especificada.");
                return;
            }

            int totalRows = 0;
            int insertedRows = 0;
            int errorRows = 0;

            using (var workbook = new XLWorkbook(excelFilePath))
            {
                var worksheet = workbook.Worksheets.First();
                var rows = worksheet.RowsUsed().Skip(1).ToList(); // Saltar encabezados
                totalRows = rows.Count;

                // Configuración inicial de la barra de progreso
                _progressBar.Invoke((Action)(() =>
                {
                    _progressBar.Maximum = totalRows;
                    _progressBar.Value = 0;
                    _progressBar.Style = ProgressBarStyle.Continuous;
                }));

                using (var connection = new NpgsqlConnection(_connectionString))
                {
                    connection.Open();

                    foreach (var row in rows)
                    {
                        try
                        {
                            string nombre = row.Cell(2).GetValue<string>();
                            string descripcion = row.Cell(5).GetValue<string>();
                            string version = row.Cell(1).GetValue<string>();
                            string equipo = row.Cell(6).GetValue<string>();
                            string disciplina = row.Cell(7).GetValue<string>();
                            string subdisciplina = row.Cell(8).GetValue<string>();
                            string categoria = row.Cell(4).GetValue<string>();
                            string url = "/" + equipo + "/" + disciplina + "/" + subdisciplina;

                            // Obtener IDs desde tablas relacionadas
                            int versionId = GetIdFromTable(connection, "TBLVERSIONS", "NAME", version);
                            int equipoId = GetIdFromTable(connection, "TBLTEAMS", "NAME", equipo);
                            int disciplinaId = GetIdFromTable(connection, "TBLDISCIPLINES", "NAME", disciplina);
                            int subdisciplinaId = GetIdFromTable(connection, "TBLSUBDISCIPLINES", "NAME", subdisciplina);
                            int categoriaId = GetIdFromTable(connection, "TBLCATEGORIES", "NAME", categoria);
                            
                            // Si no se encuentran los IDs, registrar el error y continuar
                            if (versionId == -1)
                            {
                                LogError($"Error al procesar registro: Nombre='{nombre}'. No se encontró el ID de versión para '{version}'.");
                                errorRows++;
                            }

                            if (equipoId == -1)
                            {
                                LogError($"Error al procesar registro: Nombre='{nombre}'. No se encontró el ID de equipo para '{equipo}'.");
                                errorRows++;
                            }

                            if (disciplinaId == -1)
                            {
                                LogError($"Error al procesar registro: Nombre='{nombre}'. No se encontró el ID de disciplina para '{disciplina}'.");
                                errorRows++;
                            }

                            if (subdisciplinaId == -1)
                            {
                                LogError($"Error al procesar registro: Nombre='{nombre}'. No se encontró el ID de subdisciplina para '{subdisciplina}'.");
                                errorRows++;
                            }
                            if (categoriaId == -1)
                            {
                                LogError($"Error al procesar registro: Nombre='{nombre}'. No se encontró el ID de categoria para '{categoria}'.");
                                errorRows++;
                            }

                            if (versionId == -1 || equipoId == -1 || disciplinaId == -1 || subdisciplinaId == -1 || categoriaId == -1)
                            {
                                LogError($"Error al procesar registro: Nombre='{nombre}'. Uno o más IDs no se encontraron.");
                                continue;
                            }
                            var existsQuery = $"SELECT COUNT(1) FROM \"TBLFAMILIES\" WHERE \"NAME\" = @nombre";
                            using (var cmd = new NpgsqlCommand(existsQuery, connection))
                            {
                                cmd.Parameters.AddWithValue("nombre", nombre);
                                var exists = Convert.ToInt32(cmd.ExecuteScalar()) > 0;

                                if (!exists)
                                {
                                    // Insertar registro en la base de datos
                                    var insertQuery = @"
                                INSERT INTO ""TBLFAMILIES"" 
                                (""NAME"", ""DESCRIPTION"", ""VERSION_ID"", ""TEAM_ID"", ""DISCIPLINE_ID"", ""SUBDISCIPLINE_ID"", ""CATEGORY_ID"", ""URL"") 
                                VALUES (@nombre, @descripcion, @versionId, @equipoId, @disciplinaId, @subdisciplinaId, @categoriaId, @url)";

                                    using (var insertCmd = new NpgsqlCommand(insertQuery, connection))
                                    {
                                        insertCmd.Parameters.AddWithValue("nombre", nombre);
                                        insertCmd.Parameters.AddWithValue("descripcion", descripcion);
                                        insertCmd.Parameters.AddWithValue("versionId", versionId);
                                        insertCmd.Parameters.AddWithValue("equipoId", equipoId);
                                        insertCmd.Parameters.AddWithValue("disciplinaId", disciplinaId);
                                        insertCmd.Parameters.AddWithValue("subdisciplinaId", subdisciplinaId);
                                        insertCmd.Parameters.AddWithValue("categoriaId", categoriaId);
                                        insertCmd.Parameters.AddWithValue("url", url);

                                        insertCmd.ExecuteNonQuery();
                                        insertedRows++;
                                    }
                                }
                            }
                        }
                        catch (Exception ex)
                        {
                            LogError($"Error al procesar registro: {ex.Message}");
                            errorRows++;
                        }
                        finally
                        {
                            _progressBar.Invoke((Action)(() =>
                            {
                                _progressBar.Value++;
                            }));
                        }
                    }
                }
            }

            // Mostrar resultados
            string resultMessage;
            if (errorRows > 0)
            {
                resultMessage = $"Proceso finalizado con errores. Registros insertados: {insertedRows}/{totalRows}. Registros con errores: {errorRows}.";
            }
            else
            {
                resultMessage = $"Proceso finalizado con éxito. Todos los registros nuevos han sido insertados. Total: {insertedRows}/{totalRows}.";
            }

            MessageBox.Show(resultMessage);

            // Abrir log si hay errores
            if (File.Exists(_logFilePath))
            {
                System.Diagnostics.Process.Start("notepad.exe", _logFilePath);
            }
        }

        private int GetIdFromTable(NpgsqlConnection connection, string tableName, string columnName, string value)
        {
            var query = $@"SELECT ""ID"" FROM ""{tableName}"" WHERE LOWER(""{columnName}"") = LOWER(@value)";
            using (var cmd = new NpgsqlCommand(query, connection))
            {
                cmd.Parameters.AddWithValue("value", value);
                var result = cmd.ExecuteScalar();
                return result != null ? Convert.ToInt32(result) : -1;
            }
        }

        private void LogError(string message)
        {
            File.AppendAllText(_logFilePath, $"{DateTime.Now}: {message}{Environment.NewLine}");
        }
    }
}