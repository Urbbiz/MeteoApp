
using Meteo.Meteo.Model;
using Meteo.Meteo.IO;
using Meteo.Meteo.Helper;
using Meteo.Meteo.Validation;
using Newtonsoft.Json;

var Input = new Input();

var InputValidation = new InputValidation(Input);

var StringModifier = new StringModifier(Input); 

var httpClient = new HttpClient();

var httpResponse = await httpClient.GetAsync("https://api.meteo.lt/v1/places");


// Get all places
if (httpResponse.IsSuccessStatusCode)
{
    Console.WriteLine("Meteo.lt forecast! ");
    Place filteredPlaces;
    do
    {
        Console.WriteLine("Please enter place name");

        string inputString = Input.GetInputString();

        while (InputValidation.IsOnlyLetters(inputString) == false)
        {
            Console.WriteLine("Only letters are allowed. try again!");

            inputString = Input.GetInputString();
        }

        string placeInput = StringModifier.GetUppercaseFirst(inputString);

        var contentString = await httpResponse.Content.ReadAsStringAsync();

        var places = JsonConvert.DeserializeObject<List<Place>>(contentString);

        filteredPlaces = places.Where(p => p.Name.Contains(placeInput)).FirstOrDefault();

        if (filteredPlaces == null)
        {
            Console.WriteLine("No such places in our database. Please try again!");
        }
    } while (filteredPlaces == null);

    httpResponse = await httpClient.GetAsync($"https://api.meteo.lt/v1/places/{filteredPlaces.Code}/forecasts/long-term");

    if (httpResponse.IsSuccessStatusCode)
    {

        var contentString = await httpResponse.Content.ReadAsStringAsync();

        var responseDatas = JsonConvert.DeserializeObject<ResponseData>(contentString);

        Console.WriteLine("Please chose your forecast:\n 1 = Today \n 2 = Tomorow  \n 3 = Day after tomorow \n 4 = For 5 days in a row");

        string switchInput = Input.GetInputString();

        while (InputValidation.IsNumberRange1To4(switchInput) == false)
        {
            Console.WriteLine("Only number range 1-4 are allowed. try again!");

            switchInput = Input.GetInputString();
        }

        switch (switchInput)
        {
            case "1":
                // GET FORECAST FOR TODAY
                var currentDate = DateOnly.FromDateTime(DateTime.Now).ToString();
                for (int i = 0; i < responseDatas.forecastTimestamps.Count; i += 4)
                {
                    if (currentDate == responseDatas.forecastTimestamps[i].ForecastTimeUtc.Substring(0, 10))
                    {
                        Console.WriteLine();
                        Console.WriteLine("Time: " + responseDatas.forecastTimestamps[i].ForecastTimeUtc);
                        Console.WriteLine("Place: " + responseDatas.Place.Name);
                        Console.WriteLine("Wheather condition: " + responseDatas.forecastTimestamps[i].ConditionCode);
                        Console.WriteLine($"Temperature: {responseDatas.forecastTimestamps[i].AirTemperature} °C");
                        Console.WriteLine($"Wind speed:{ responseDatas.forecastTimestamps[i].WindSpeed} m/s. ");
                        Console.WriteLine($"Humidity: {responseDatas.forecastTimestamps[i].RelativeHumidity}%");
                        Console.WriteLine($"Pressure: {responseDatas.forecastTimestamps[i].SeaLevelPressure} hPa");
                        Console.WriteLine();
                    }
                }
                break;

            case "2":
                // GET FORECAST FOR TOMOROW
                var tomorowDate = DateOnly.FromDateTime(DateTime.Now.AddDays(1)).ToString();
                for (int i = 0; i < responseDatas.forecastTimestamps.Count; i += 4)
                {
                    if (tomorowDate == responseDatas.forecastTimestamps[i].ForecastTimeUtc.Substring(0, 10))
                    {
                        Console.WriteLine();
                        Console.WriteLine("Time: " + responseDatas.forecastTimestamps[i].ForecastTimeUtc);
                        Console.WriteLine("Place: " + responseDatas.Place.Name);
                        Console.WriteLine("Wheather condition: " + responseDatas.forecastTimestamps[i].ConditionCode);
                        Console.WriteLine($"Temperature: {responseDatas.forecastTimestamps[i].AirTemperature} °C");
                        Console.WriteLine($"Wind speed:{ responseDatas.forecastTimestamps[i].WindSpeed} m/s. ");
                        Console.WriteLine($"Humidity: {responseDatas.forecastTimestamps[i].RelativeHumidity}%");
                        Console.WriteLine($"Pressure: {responseDatas.forecastTimestamps[i].SeaLevelPressure} hPa");
                        Console.WriteLine();
                    }
                }
                break;

            case "3":
                // GET FORECAST FOR TOMOROW
                var dateAfterTomorow = DateOnly.FromDateTime(DateTime.Now.AddDays(2)).ToString();
                for (int i = 0; i < responseDatas.forecastTimestamps.Count; i += 5)
                {
                    if (dateAfterTomorow == responseDatas.forecastTimestamps[i].ForecastTimeUtc.Substring(0, 10))
                    {
                        Console.WriteLine();
                        Console.WriteLine("Time: " + responseDatas.forecastTimestamps[i].ForecastTimeUtc);
                        Console.WriteLine("Place: " + responseDatas.Place.Name);
                        Console.WriteLine("Wheather condition: " + responseDatas.forecastTimestamps[i].ConditionCode);
                        Console.WriteLine($"Temperature: {responseDatas.forecastTimestamps[i].AirTemperature} °C");
                        Console.WriteLine($"Wind speed:{ responseDatas.forecastTimestamps[i].WindSpeed} m/s. ");
                        Console.WriteLine($"Humidity: {responseDatas.forecastTimestamps[i].RelativeHumidity}%");
                        Console.WriteLine($"Pressure: {responseDatas.forecastTimestamps[i].SeaLevelPressure} hPa");
                        Console.WriteLine();
                    }
                }
                break;

            case "4":
                // GET FORECAST FOR 5 DAYS
                for (int i = 0; i < responseDatas.forecastTimestamps.Count; i += 4)
                {
                    Console.WriteLine();
                    Console.WriteLine("Time: " + responseDatas.forecastTimestamps[i].ForecastTimeUtc);
                    Console.WriteLine("Place: " + responseDatas.Place.Name);
                    Console.WriteLine("Wheather condition: " + responseDatas.forecastTimestamps[i].ConditionCode);
                    Console.WriteLine($"Temperature: {responseDatas.forecastTimestamps[i].AirTemperature} °C");
                    Console.WriteLine($"Wind speed:{ responseDatas.forecastTimestamps[i].WindSpeed} m/s. ");
                    Console.WriteLine($"Humidity: {responseDatas.forecastTimestamps[i].RelativeHumidity}%");
                    Console.WriteLine($"Pressure: {responseDatas.forecastTimestamps[i].SeaLevelPressure} hPa");
                    Console.WriteLine();
                }
                break;
        }   
    
    }
     
}
    

