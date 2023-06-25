using Microsoft.EntityFrameworkCore;
using MoscowWeather.Host.Domain;

namespace MoscowWeather.Host.Persistance;

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options)
        :base(options)
    {
    }
    public DbSet<WeatherLog> WeatherLogs => Set<WeatherLog>();
	protected override void OnModelCreating(ModelBuilder modelBuilder)
	{
		base.OnModelCreating(modelBuilder);
		modelBuilder.ApplyConfigurationsFromAssembly(GetType().Assembly);
	}
}
