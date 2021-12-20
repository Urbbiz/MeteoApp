using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Meteo.Meteo.Helper
{
    internal static class Message 
    {
     public static string welcome = "Welcome to Meteo.lt forecast app!";

     public static string enterPlace = "Please enter place name";

     public static string onlyLettersValid = "Only letters are allowed. try again!";

     public static string placeInvalid = "No such places in our database. Please try again!";

     public static string switchOptions = "Please chose your forecast:\n 1 = Today \n 2 = Tomorrow" +
                                         " \n 3 = Day after tomorrow \n 4 = For 5 days in a row";

     public static string switchInputInvalid = "Only number range 1-4 are allowed. try again!";
    }
}
