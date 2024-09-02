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
        public static readonly string logFilePath = "log.txt";
        public static int countErrors = 0;

        public static void Log(string message)
        {
            countErrors++;
            using (StreamWriter writer = new StreamWriter(logFilePath, true))
            {
                writer.WriteLine($"{DateTime.Now}: {message}");
            }
        }

        public static bool HasErrors()
        {
            return countErrors > 0;
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
