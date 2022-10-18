namespace WeatherTracker.Models;

public class City
{
    public int Id { get; set; }

    public string Name { get; set; }

    public decimal Latitude { get; set; }

    public decimal Longitude { get; set; }

    public List<WeatherData> WeatherData { get; set; } = new();

    public WeatherData? LatestWeatherData => WeatherData.LastOrDefault();
}