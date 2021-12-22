using System;
using System.Collections.Generic;
using System.Collections;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.Json.Serialization;

namespace Meteo.Meteo.Model
{
    public class ForecastTimestamp
    {
        
        public string? ForecastTimeUtc { get; set; }
        public float? AirTemperature { get; set; }
        public string? ConditionCode { get; set; }
        public int? WindSpeed { get; set; }
        public int? CloudCover { get; set; }
        public int? SeaLevelPressure { get; set; }
        public int? RelativeHumidity { get; set; }
        




    }
}
