
using Meteo.Meteo.Model;
using Meteo.Meteo.IO;
using Meteo.Meteo.Helper;
using Meteo.Meteo.Validation;
using Meteo.Meteo.Services;

var Input = new Input();

var inputValidation = new InputValidation();

var meteoService = new MeteoService();

 Place? place;

 PlaceForecast? placeForecast;

    do
    {
    Console.WriteLine(Message.welcome);
    Console.WriteLine(Message.enterPlace);

    string? inputString = Input.GetInputString();
        
    while (inputValidation.IsOnlyLetters(inputString) == false)
    {
        Console.WriteLine(Message.onlyLettersValid);

        inputString = Input.GetInputString();
        }
       
    string placeInput = inputString.GetUppercaseFirst();

    place = await meteoService.GetPlaceByName(placeInput);

    if(place == null)
    {
       Console.WriteLine(Message.placeInvalid);
    }

    } while (place == null);

        
        placeForecast = await meteoService.GetPlaceForecast(place);
    
        Console.WriteLine(Message.switchOptions);

        string? switchInput = Input.GetInputString();
        
        while (inputValidation.IsNumberRange1To4(switchInput) == false)
        {
            Console.WriteLine(Message.switchInputInvalid);

            switchInput = Input.GetInputString();
        }

        for (int i = 0; i < placeForecast.forecastTimestamps.Count; i += 4)   
        {
            string forecastTimeStamp = placeForecast.forecastTimestamps[i].ForecastTimeUtc.Substring(0, 10);

            string forecastMessage = $"\nTime:{ placeForecast.forecastTimestamps[i].ForecastTimeUtc}\n" +
                $"Place:{placeForecast.Place.Name} \n" +
                $"Wheather condition:{placeForecast.forecastTimestamps[i].ConditionCode} \n" +
                $"Temperature: {placeForecast.forecastTimestamps[i].AirTemperature} °C \n" +
                $"Wind speed:{placeForecast.forecastTimestamps[i].WindSpeed} m/s. \n" +
                $"Humidity: {placeForecast.forecastTimestamps[i].RelativeHumidity}% \n" +
                $"Pressure: {placeForecast.forecastTimestamps[i].SeaLevelPressure} hPa";

            switch (switchInput)
            {
                case "1":
                    // GET FORECAST FOR TODAY
                    var currentDate = DateOnly.FromDateTime(DateTime.Now).ToString();

                    if (currentDate == forecastTimeStamp)
                    {
                        Console.WriteLine(forecastMessage);
                    }
                    break;

                case "2":
                    // GET FORECAST FOR TOMOROW
                    var tomorowDate = DateOnly.FromDateTime(DateTime.Now.AddDays(1)).ToString();

                    if (tomorowDate == forecastTimeStamp)
                    {
                        Console.WriteLine(forecastMessage);
                    }
                    break;

                case "3":
                    // GET FORECAST FOR TOMOROW
                    var dateAfterTomorow = DateOnly.FromDateTime(DateTime.Now.AddDays(2)).ToString();

                    if (dateAfterTomorow == forecastTimeStamp)
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
   