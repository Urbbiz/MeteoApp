using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Meteo.Meteo.IO;

namespace Meteo.Meteo.Helper
{
    internal class StringModifier
    {
        public StringModifier(Input input)
        {

        }
       public string GetUppercaseFirst(string inputString)
        {
            if (string.IsNullOrEmpty(inputString))
                return string.Empty;
            return char.ToUpper(inputString[0]) + inputString.Substring(1).ToLower();
        }
    }
}
