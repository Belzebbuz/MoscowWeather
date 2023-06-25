using MoscowWeather.Host.Dtos;

namespace MoscowWeather.Host.Models;

public class ViewArchivesModel
{
    public PaginatedResult<WeatherLogDto> Result { get; set; }
    public List<int> Years { get; set; }
    public QueryFilter Query { get; set; } = new();
}

public class QueryFilter
{
	public QueryFilter(int page, int? year, int? month)
	{
		Page = page;
		Year = year;
		Month = month;
	}
    public QueryFilter()
    {
    }
    public int Page { get; set; } = 1;
    public int? Year { get; set; }
    public int? Month { get; set; }
}