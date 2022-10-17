using WeatherTracker.Models;

namespace WeatherTracker.Services;

public interface ICityService
{
    Task<City> GetCityAsync(int id);
    Task<IEnumerable<City>> GetAllCitiesAsync();
    Task AddCityAsync(City city);
    Task DeleteCityAsync(int id);
}