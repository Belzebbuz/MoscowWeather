using MoscowWeather.Host.Domain;

namespace MoscowWeather.Host.Contracts;

public interface IDataExtractService
{
    public List<WeatherLog> GetData(Stream exelFileStream);
}
