using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace organizadorFamilia.Services
{
    public static class LoggerService
    {
        private static readonly string logFilePath = "log.txt";

        public static void Log(string message)
        {
            using (StreamWriter writer = new StreamWriter(logFilePath, true))
            {
                writer.WriteLine($"{DateTime.Now}: {message}");
            }
        }

        public static bool HasErrors()
        {
            return File.Exists(logFilePath) && new FileInfo(logFilePath).Length > 0;
        }

        public static void ClearLog()
        {
            if (File.Exists(logFilePath))
            {
                File.Delete(logFilePath);
            }
        }
    }
}
