using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using Meteo.Meteo.IO;

namespace Meteo.Meteo.Validation
{
    internal class InputValidation
    {
        public InputValidation(Input input)
        {

        }

        public bool? IsOnlyLetters( string input)
        {

            if (!Regex.IsMatch(input, @"^[a-zA-Z]+$"))
            {
                return false;
            } else

                return Regex.IsMatch(input, @"^[a-zA-Z]+$");
        }
    }
}
