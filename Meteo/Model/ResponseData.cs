﻿using System;
using System.Collections.Generic;
using System.Collections;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Meteo.Meteo.Model
{
    internal class ResponseData
    {
         public Place? Place { get; set; }
        public List<ForecastTimestamps>? forecastTimestamps{ get; set; }
        public string? ForecastType { get; set; }
        public string? ForecastCreationTimeUtc { get; set; }





    }
}
