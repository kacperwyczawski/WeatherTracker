namespace WeatherTracker.Models;

public class WeatherData
{
    public int Id { get; set; }

    public int CityId { get; set; }

    public City City { get; set; }

    public DateTime Date { get; set; }

    public decimal Temperature { get; set; }

    public decimal Humidity { get; set; }

    public string IconId { get; set; }
}