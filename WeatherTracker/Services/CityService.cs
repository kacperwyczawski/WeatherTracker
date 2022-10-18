using Microsoft.EntityFrameworkCore;
using WeatherTracker.Data;
using WeatherTracker.Models;

namespace WeatherTracker.Services;

public class CityService : ICityService
{
    private readonly WeatherTrackerDbContext _context;

    public CityService(WeatherTrackerDbContext context)
    {
        _context = context;
    }

    public async Task<City> GetCityAsync(int id) =>
        await _context.UserCities.AsNoTracking().FirstOrDefaultAsync(c => c.Id == id)
        ?? throw new Exception("City not found");

    public async Task<IEnumerable<City>> GetAllCitiesAsync() =>
        await _context.UserCities.Include(city => city.WeatherData).AsNoTracking().ToListAsync();

    public async Task AddCityAsync(City city)
    {
        await _context.UserCities.AddAsync(city);
        await _context.SaveChangesAsync();
    }

    public async Task DeleteCityAsync(int id)
    {
        var city = await _context.UserCities.FindAsync(id);
        
        if (city is null)
            return;
        
        _context.UserCities.Remove(city);
        await _context.SaveChangesAsync();
    }

    public async Task AddWeatherDataAsync(int id, WeatherData data)
    {
        var city = await _context.UserCities.FindAsync(id) ?? throw new Exception("City not found");
        city.WeatherData.Add(data);
        await _context.SaveChangesAsync();
    }
}