using NPOI.SS.Formula.Functions;

namespace MoscowWeather.Host.Dtos;

public class PaginatedResult<T>
{
	public PaginatedResult(List<T> data, int count, int page, int pageSize)
	{
		Data = data;
		TotalPageCount = (int)Math.Ceiling(count / (double)pageSize);
		CurrentPage = page;
		HasNextPage = CurrentPage < TotalPageCount;
		HasPreviousPage = CurrentPage > 1;
	}

	public List<T> Data { get; set; }
	public bool HasNextPage { get; set; }
	public bool HasPreviousPage { get; set; }
	public int TotalPageCount { get; set; }
	public int CurrentPage { get; set; }
}
