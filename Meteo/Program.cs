
using Meteo.Meteo.Model;
using Newtonsoft.Json;

Console.WriteLine("Hello, World!");

var httpClient = new HttpClient();

var httpResponse = await httpClient.GetAsync("https://api.meteo.lt/v1/places");

// Get all places
if (httpResponse.IsSuccessStatusCode)
{
    Console.WriteLine(httpResponse.StatusCode.ToString());

    var contentString = await httpResponse.Content.ReadAsStringAsync();

    Console.WriteLine("Please enter place");

    string placeInput = Console.ReadLine();

    var places = JsonConvert.DeserializeObject<List<Place>>(contentString);

    var filteredPlaces = places.Where(p => p.Code.Contains(placeInput));

    //foreach(var place in filteredPlaces)
    //{
    //    Console.WriteLine($"Vietove: {place.Name}, kodas: {place.CountryCode} Rajonas: {place.AdministrativeDivision}, Salies kodas: {place.Code}");
    //}

    httpResponse = await httpClient.GetAsync("https://api.meteo.lt/v1/places/vilnius/forecasts/long-term");

    if (httpResponse.IsSuccessStatusCode)
    {
        contentString = await httpResponse.Content.ReadAsStringAsync();

     var responseDatas = JsonConvert.DeserializeObject<ResponseData>(contentString);

        Console.WriteLine("Time: " + responseDatas.forecastTimestamps[1].ForecastTimeUtc);
        Console.WriteLine("Place: " + responseDatas.Place.Name);
        Console.WriteLine("Wheather condition: " + responseDatas.forecastTimestamps[1].ConditionCode);
        Console.WriteLine("Temperature: " + responseDatas.forecastTimestamps[1].AirTemperature);
        Console.WriteLine($"Temperature:{ responseDatas.forecastTimestamps[1].WindSpeed} m/s. ");
        Console.WriteLine($"Humidity: {responseDatas.forecastTimestamps[1].RelativeHumidity}%");
        Console.WriteLine($"Humidity: {responseDatas.forecastTimestamps[1].SeaLevelPressure} hPa");

    }
}

