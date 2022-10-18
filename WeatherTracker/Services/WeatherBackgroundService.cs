using System.Text.Json.Serialization;
using WeatherTracker.Models;

namespace WeatherTracker.Services;

public class WeatherBackgroundService : BackgroundService
{
    private readonly IHttpClientFactory _httpClientFactory;

    private readonly IServiceProvider _serviceProvider;
    private readonly PeriodicTimer _timer = new(TimeSpan.FromMinutes(30));

    public WeatherBackgroundService(IHttpClientFactory httpClientFactory, IServiceProvider serviceProvider)
    {
        _httpClientFactory = httpClientFactory;
        _serviceProvider = serviceProvider;
    }

    protected override async Task ExecuteAsync(CancellationToken stoppingToken)
    {
        using var scope = _serviceProvider.CreateScope();
        var cityService = scope.ServiceProvider.GetService<ICityService>();

        do
        {
            await UpdateWeather(cityService, stoppingToken);
        } while (await _timer.WaitForNextTickAsync(stoppingToken)
                 && !stoppingToken.IsCancellationRequested);
    }

    private async Task UpdateWeather(ICityService cityService, CancellationToken stoppingToken)
    {
        foreach (var city in await cityService.GetAllCitiesAsync())
        {
            Root? weather;

            // get current weather
            var client = _httpClientFactory.CreateClient();

            var response = await client.GetAsync("https://api.openweathermap.org/data/2.5/weather" +
                                                 $"?lat={city.Latitude}" +
                                                 $"&lon={city.Longitude}" +
                                                 "&appid=73f26086a5140f643f3b25bf3d7a5c29" +
                                                 "&units=metric", stoppingToken);

            // deserialize
            if (response.IsSuccessStatusCode)
                weather = await response.Content.ReadFromJsonAsync<Root>(cancellationToken: stoppingToken);
            else
                throw new Exception("Http request failed");

            // add weather to db
            var weatherData = new WeatherData
            {
                Date = DateTime.Now,
                Humidity = weather.Main.Humidity,
                Temperature = weather.Main.Temperature,
                IconId = weather.Weather[0].Icon
            };

            await cityService.AddWeatherDataAsync(city.Id, weatherData);
        }
    }

    private class Main
    {
        [JsonPropertyName("temp")] public decimal Temperature { get; set; }
        [JsonPropertyName("humidity")] public int Humidity { get; set; }
    }

    private class Root
    {
        [JsonPropertyName("weather")] public List<Weather> Weather { get; set; }
        [JsonPropertyName("main")] public Main Main { get; set; }
    }

    private class Weather
    {
        [JsonPropertyName("icon")] public string Icon { get; set; }
    }
}