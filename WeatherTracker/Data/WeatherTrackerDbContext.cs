using Microsoft.EntityFrameworkCore;
using WeatherTracker.Models;

namespace WeatherTracker.Data;

public class WeatherTrackerDbContext : DbContext
{
    public WeatherTrackerDbContext(DbContextOptions options)
        : base(options)
    {
    }

    public DbSet<City> UserCities => Set<City>();

    public DbSet<WeatherData> WeatherDataSets => Set<WeatherData>();
}