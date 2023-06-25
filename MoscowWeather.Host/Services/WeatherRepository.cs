using Mapster;
using Microsoft.EntityFrameworkCore;
using MoscowWeather.Host.Contracts;
using MoscowWeather.Host.Domain;
using MoscowWeather.Host.Dtos;
using MoscowWeather.Host.Persistance;

namespace MoscowWeather.Host.Services;

public class WeatherRepository : IWeatherRepository
{
    private readonly AppDbContext _context;

    public WeatherRepository(AppDbContext context)
    {
        _context = context;
    }
    public async Task CreateAsync(List<WeatherLog> logs)
    {
        await _context.WeatherLogs.AddRangeAsync(logs);
        await _context.SaveChangesAsync();
    }

    public async Task<PaginatedResult<WeatherLogDto>> GetAsync(int? year, int? month, int page, int pageSize = 10)
    {
        var query = _context.WeatherLogs.AsQueryable();
        if (year != null)
			query = query.Where(x => x.Date.Year == year);
        if (month != null)
			query = query.Where(x => x.Date.Month == month);

        var count = await query.CountAsync();
        var logs = await query
            .OrderBy(x => x.Date)
			.Skip((page - 1) * pageSize)
            .Take(pageSize)
            .ToListAsync();
        return new(logs.Adapt<List<WeatherLogDto>>(), count, page, pageSize);
    }

	public async Task<List<int>> GetTotalYearsAsync()
	{
		return await _context.WeatherLogs.Select(x => x.Date.Year).Distinct().ToListAsync();
	}
}