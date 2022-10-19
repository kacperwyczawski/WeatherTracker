using WeatherTracker.Models;

namespace WeatherTracker.Services;

public interface ICityService
{
    Task<City> GetCityAsync(int id);
    Task<IEnumerable<City>> GetAllCitiesAsync();
    Task AddCityAsync(City city);
    Task DeleteCityAsync(int id);
    Task AddWeatherDataAsync(int id, WeatherData data);
    Task<bool> IsInUserCities(string name, int latitude, int longitude);
}