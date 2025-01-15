using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace organizadorFamilia.Domain
{
    public static class ConfigReader
    {
        public static Connection LoadConnectionConfig(string filePath,Connection connection)
        {

            if (!File.Exists(filePath))
                throw new FileNotFoundException("Configuration file not found.", filePath);

            var lines = File.ReadAllLines(filePath);
            foreach (var line in lines)
            {
                var keyValue = line.Split('=');
                if (keyValue.Length == 2)
                {
                    var key = keyValue[0].Trim();
                    var value = keyValue[1].Trim();

                    switch (key)
                    {
                        case "Server":
                            connection.Server = value;
                            break;
                        case "Port":
                            connection.Port = value;
                            break;
                        case "Database":
                            connection.Database = value;
                            break;
                        case "Username":
                            connection.Username = value;
                            break;
                        case "Password":
                            connection.Password = value;
                            break;
                    }
                }
            }

            return connection;
        }
    }
    }
