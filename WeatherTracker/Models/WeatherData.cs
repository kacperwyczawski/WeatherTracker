namespace WeatherTracker.Models;

public class WeatherData
{
    public int Id { get; set; }

    public DateTime Date { get; set; }

    public double Temperature { get; set; }

    public double Humidity { get; set; }
}