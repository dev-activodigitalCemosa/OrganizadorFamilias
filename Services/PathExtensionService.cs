using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace organizadorFamilia.Services
{
    public static class PathExtensionService
    {
        public static string NormalizePath(this string path)
        {
            if (path == null)
                return null;

            // Normalizar la ruta y eliminar los acentos
            return path.Normalize(NormalizationForm.FormD)
                       .Where(c => CharUnicodeInfo.GetUnicodeCategory(c) != UnicodeCategory.NonSpacingMark)
                       .Aggregate(new StringBuilder(), (sb, c) => sb.Append(c))
                       .ToString()
                       .Normalize(NormalizationForm.FormC);
        }

    }
}
