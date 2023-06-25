using MoscowWeather.Host.Domain;
using MoscowWeather.Host.Dtos;
namespace MoscowWeather.Host.Contracts;

public interface IWeatherRepository
{
    public Task CreateAsync(List<WeatherLog> logs);
    public Task<PaginatedResult<WeatherLogDto>> GetAsync(int? year, int? month, int page, int pageSize = 15);
    public Task<List<int>> GetTotalYearsAsync();
}
