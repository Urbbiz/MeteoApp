using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using Meteo.Meteo.IO;

namespace Meteo.Meteo.Validation
{
    internal class InputValidation : IInputValidation
    {
        public InputValidation(Input input)
        {

        }

        public bool? IsOnlyLetters( string input)
        {

            if (!Regex.IsMatch(input, @"^[a-zA-Z]+$"))
            {
                return false;
            }else

                return Regex.IsMatch(input, @"^[a-zA-Z]+$");
        }

        public bool? IsNumberRange1To4(string input)
        {
            if (!Regex.IsMatch(input, "^[0-4]$") )
            {
                return false;
            }else
            
                return Regex.IsMatch(input, "^[0-4]$");  
        }
    }
}
