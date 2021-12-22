using Meteo.Meteo.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Meteo.Meteo.Services
{
    internal interface IMeteoService
    {
         Task<Place?> GetPlaceByName(string name);

        Task<PlaceForecast?> GetPlaceForecast(Place filtredPlace);
    }
}
