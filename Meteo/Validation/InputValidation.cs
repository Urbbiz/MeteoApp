using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Meteo.Meteo.Model;

namespace Meteo.Meteo.Validation
{
    internal class InputValidation
    {

        
        public bool IsPlaceInputValid( string str)
        {
         
            if (str == "null")
            {
                return false;
            }

            return true;
        }
    }
}
