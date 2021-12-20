using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Meteo.Meteo.Validation
{
    internal interface IInputValidation
    {

        bool? IsOnlyLetters(string input);

        bool? IsNumberRange1To4(string input);
    }
}
