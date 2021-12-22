using Meteo.Meteo.Model;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Meteo.Meteo.Services
{
    public class MeteoService
    {
        private readonly HttpClient _httpClient;
        private const string PlacesUrl = "https://api.meteo.lt/v1/places/";
        private const string NameString ="Vilnius";

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

            return null;

            //public List<ForecastTimestamps> GetForecastTimestamps()
            //{

            //}
        }
    }
}
