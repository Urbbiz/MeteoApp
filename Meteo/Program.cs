// See https://aka.ms/new-console-template for more information
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

    var places = JsonConvert.DeserializeObject<List<Place>>(contentString);

    var filteredPlaces = places.Where(p => p.Name == "Druskininkai");

    foreach(var place in filteredPlaces)
    {
        Console.WriteLine($"Vietove: {place.Name}, kodas: {place.CountryCode} Rajonas: {place.AdministrativeDivision}, Salies kodas: {place.CountryCode}");
    }
  
}

