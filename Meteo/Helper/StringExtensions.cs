using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Meteo.Meteo.IO;

namespace Meteo.Meteo.Helper
{
    public static class StringExtensions
    {
       
       public static string GetUppercaseFirst(this string inputString)
        {
            if (string.IsNullOrEmpty(inputString))
                return string.Empty;
            return char.ToUpper(inputString[0]) + inputString.Substring(1).ToLower();
        }
    }
}
