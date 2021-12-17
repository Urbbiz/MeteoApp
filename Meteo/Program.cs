
using Meteo.Meteo.Model;
using Newtonsoft.Json;

Console.WriteLine("Meteo.lt forecast! ");

var httpClient = new HttpClient();

var httpResponse = await httpClient.GetAsync("https://api.meteo.lt/v1/places");

// Get all places
if (httpResponse.IsSuccessStatusCode)
{
    Console.WriteLine(httpResponse.StatusCode.ToString());

    var contentString = await httpResponse.Content.ReadAsStringAsync();

    Console.WriteLine("Please enter place name");

    string placeInput = Console.ReadLine();

    string placeInputNew = char.ToUpper(placeInput.First()) + placeInput.Substring(1).ToLower();

    var places = JsonConvert.DeserializeObject<List<Place>>(contentString);

    var filteredPlaces = places.Where(p => p.Name.Contains(placeInputNew)).FirstOrDefault();


        httpResponse = await httpClient.GetAsync($"https://api.meteo.lt/v1/places/{filteredPlaces.Code}/forecasts/long-term");

        if (httpResponse.IsSuccessStatusCode)
        {
            contentString = await httpResponse.Content.ReadAsStringAsync();

            var responseDatas = JsonConvert.DeserializeObject<ResponseData>(contentString);

        for (int i = 0; i < responseDatas.forecastTimestamps.Count; i+=3)
             {
            Console.WriteLine();
            Console.WriteLine("Time: " + responseDatas.forecastTimestamps[i].ForecastTimeUtc);
            Console.WriteLine("Place: " + responseDatas.Place.Name);
            Console.WriteLine("Wheather condition: " + responseDatas.forecastTimestamps[i].ConditionCode);
            Console.WriteLine($"Temperature: {responseDatas.forecastTimestamps[i].AirTemperature} °C");
            Console.WriteLine($"Temperature:{ responseDatas.forecastTimestamps[i].WindSpeed} m/s. ");
            Console.WriteLine($"Humidity: {responseDatas.forecastTimestamps[i].RelativeHumidity}%");
            Console.WriteLine($"Humidity: {responseDatas.forecastTimestamps[i].SeaLevelPressure} hPa");
            Console.WriteLine();
         }
        }

    
}

