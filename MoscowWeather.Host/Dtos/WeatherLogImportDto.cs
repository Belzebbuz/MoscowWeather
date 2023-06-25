namespace MoscowWeather.Host.Dtos;

public class WeatherLogDto
{
	public DateTime Date { get; set; }
	public float Temperature { get; set; }
	public float RelativeHumidity { get; set; }
	public float DewPoint { get; set; }
	public ushort AtmospherePressure { get; set; }
	public byte? WindSpeed { get; set; }
	public byte Cloudiness { get; set; }
	public ushort? CloudBase { get; set; }
	public string? HorizontalVisibility { get; set; }
	public string? WeatherConditions { get; set; }
	public string? Directions { get; set; }
}
