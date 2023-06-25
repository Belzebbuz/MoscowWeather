using System;
using System.ComponentModel;

namespace MoscowWeather.Host.Domain;

/// <summary>
/// Архивная запись
/// </summary>
public sealed partial class WeatherLog
{
    public Guid Id { get; private set; }
    public DateTime Date { get; private set; }
    public float Temperature { get; private set; }
    public float RelativeHumidity { get; private set; }
    public float DewPoint { get; private set; }
    public ushort AtmospherePressure { get; private set; }
	public byte? WindSpeed { get; private set; }
	public byte Cloudiness { get; private set; }
	public ushort? CloudBase { get; private set; }
	public string? HorizontalVisibility { get; private set; }
	public string? WeatherConditions { get; private set; }
    public string? Directions { get; private set; }
    private WeatherLog() { }
}
