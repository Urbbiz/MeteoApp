using Meteo.Meteo.Model;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Meteo.Meteo.Services
{
    public class MeteoService : IMeteoService
    {
        private readonly HttpClient _httpClient;
        private const string PlacesUrl = "https://api.meteo.lt/v1/places/";
    
        public MeteoService()
        {
            _httpClient = new HttpClient();
            _httpClient.BaseAddress = new Uri(PlacesUrl);
        }

        public async Task<Place?> GetPlaceByName(string name)
        {
            var httpResponse = await _httpClient.GetAsync(name);

            if (httpResponse.IsSuccessStatusCode)
            {
                var contentString = await httpResponse.Content.ReadAsStringAsync();

                var place = JsonConvert.DeserializeObject<Place>(contentString);

                return place;
            }
            else
            {
                return null;
            }
        }

        public async Task<PlaceForecast?> GetPlaceForecast(Place filtredPlace)
        {
            var httpResponse = await _httpClient.GetAsync($"{filtredPlace.Code}/forecasts/long-term");

            if (httpResponse.IsSuccessStatusCode)
            {
                var contentString = await httpResponse.Content.ReadAsStringAsync();

                var forecast = JsonConvert.DeserializeObject<PlaceForecast>(contentString);

                return forecast;

            } else
            {
                return null;
            }
                    
        }
    }
}
