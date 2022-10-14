namespace WeatherTracker.Models;

public class City
{
    public int Id { get; set; }

    public string Name { get; set; }

    public Stack<WeatherData> WeatherData { get; set; }

    public WeatherData NewestWeatherData => WeatherData.Peek();
}