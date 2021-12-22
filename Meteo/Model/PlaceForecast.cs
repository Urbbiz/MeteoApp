using System;
using System.Collections.Generic;
using System.Collections;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Meteo.Meteo.Model
{
    public class PlaceForecast
    {
         public Place? Place { get; set; }
        public List<ForecastTimestamp>? forecastTimestamps{ get; set; }
        public string? ForecastType { get; set; }
        public string? ForecastCreationTimeUtc { get; set; }





    }
}
