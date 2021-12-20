
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
    Console.WriteLine(Message.welcome);

    Place filteredPlaces;

    do
    {
        Console.WriteLine(Message.enterPlace);

        string inputString = Input.GetInputString();

        while (InputValidation.IsOnlyLetters(inputString) == false)
        {
            Console.WriteLine(Message.onlyLettersValid);

            inputString = Input.GetInputString();
        }

        string placeInput = StringModifier.GetUppercaseFirst(inputString);

        var contentString = await httpResponse.Content.ReadAsStringAsync();

        var places = JsonConvert.DeserializeObject<List<Place>>(contentString);

        filteredPlaces = places.Where(p => p.Name.Contains(placeInput)).FirstOrDefault();

        if (filteredPlaces == null)
        {
            Console.WriteLine(Message.placeInvalid);
        }

    } while (filteredPlaces == null);

    httpResponse = await httpClient.GetAsync($"https://api.meteo.lt/v1/places/{filteredPlaces.Code}/forecasts/long-term");

    if (httpResponse.IsSuccessStatusCode)
    {
        var contentString = await httpResponse.Content.ReadAsStringAsync();

        var responseDatas = JsonConvert.DeserializeObject<ResponseData>(contentString);

        Console.WriteLine(Message.switchOptions);

        string switchInput = Input.GetInputString();
        
        while (InputValidation.IsNumberRange1To4(switchInput) == false)
        {
            Console.WriteLine(Message.switchInputInvalid);

            switchInput = Input.GetInputString();
        }

        for (int i = 0; i < responseDatas.forecastTimestamps.Count; i += 4)   
        {
            string forecastMessage = $"\nTime:{ responseDatas.forecastTimestamps[i].ForecastTimeUtc}\n" +
                $"Place:{responseDatas.Place.Name} \n" +
                $"Wheather condition:{responseDatas.forecastTimestamps[i].ConditionCode} \n" +
                $"Temperature: { responseDatas.forecastTimestamps[i].AirTemperature} °C \n" +
                $"Wind speed:{ responseDatas.forecastTimestamps[i].WindSpeed} m/s. \n" +
                $"Humidity: {responseDatas.forecastTimestamps[i].RelativeHumidity}% \n" +
                $"Pressure: {responseDatas.forecastTimestamps[i].SeaLevelPressure} hPa";

            switch (switchInput)
            {
                case "1":
                    // GET FORECAST FOR TODAY
                    var currentDate = DateOnly.FromDateTime(DateTime.Now).ToString();

                    if (currentDate == responseDatas.forecastTimestamps[i].ForecastTimeUtc.Substring(0, 10))
                    {
                        Console.WriteLine(forecastMessage);
                    }
                    break;

                case "2":
                    // GET FORECAST FOR TOMOROW
                    var tomorowDate = DateOnly.FromDateTime(DateTime.Now.AddDays(1)).ToString();

                    if (tomorowDate == responseDatas.forecastTimestamps[i].ForecastTimeUtc.Substring(0, 10))
                    {
                        Console.WriteLine(forecastMessage);
                    }
                    break;

                case "3":
                    // GET FORECAST FOR TOMOROW
                    var dateAfterTomorow = DateOnly.FromDateTime(DateTime.Now.AddDays(2)).ToString();

                    if (dateAfterTomorow == responseDatas.forecastTimestamps[i].ForecastTimeUtc.Substring(0, 10))
                    {
                        Console.WriteLine(forecastMessage);
                    }
                    break;

                case "4":
                    // GET FORECAST FOR 5 DAYS
                    Console.WriteLine(forecastMessage);

                    break;
            }
        }
    }    
}





