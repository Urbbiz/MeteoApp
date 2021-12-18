using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Meteo.Meteo.Helper;

namespace Meteo.Meteo.IO
{
    internal class Input
    {
        public string GetInputString()
        {
            string inputString = Console.ReadLine();
            return inputString;
        }
    }
}
