namespace MoscowWeather.Host.Domain;

public sealed partial class WeatherLog
{
    public sealed class WeatherLogBuilder
    {
        private readonly WeatherLog _instance = new();
        public WeatherLog Build() => _instance;
        public WeatherLogBuilder SetDay(string value)
        {
            var splited = value.Split('.');
            _instance.Date = new DateTime(int.Parse(splited[2]), int.Parse(splited[1]), int.Parse(splited[0]));
            return this;
        }
        public WeatherLogBuilder SetTime(string value)
        {
            var time = value.Split(":");
            _instance.Date = _instance.Date.AddHours(int.Parse(time[0]));
            _instance.Date = _instance.Date.AddMinutes(int.Parse(time[1]));
            return this;
        }

        public WeatherLogBuilder SetTemperature(string value)
        {
            _instance.Temperature = float.Parse(value);
            return this;
        }
        public WeatherLogBuilder SetRelativeHumidity(string value)
        {
            _instance.RelativeHumidity = float.Parse(value);
            return this;
        }
        public WeatherLogBuilder SetDewPoint(string value)
        {
            _instance.DewPoint = float.Parse(value);
            return this;
        }
        public WeatherLogBuilder SetAtmospherePressure(string value)
        {
            _instance.AtmospherePressure = ushort.Parse(value);
            return this;
        }
        public WeatherLogBuilder SetWindSpeed(string? value)
        {
            if (string.IsNullOrWhiteSpace(value))
                return this;
            _instance.WindSpeed = byte.Parse(value);
            return this;
        }
        public WeatherLogBuilder SetCloudiness(string? value)
        {
            if (string.IsNullOrWhiteSpace(value))
                return this;
            _instance.Cloudiness = byte.Parse(value);
            return this;
        }
        public WeatherLogBuilder SetCloudBase(string? value)
        {
            if (string.IsNullOrWhiteSpace(value))
                return this;
            _instance.CloudBase = ushort.Parse(value);
            return this;
        }
        public WeatherLogBuilder SetHorizontalVisibility(string? value)
        {
            if (string.IsNullOrWhiteSpace(value))
                return this;
            _instance.HorizontalVisibility = value;
            return this;
        }
        public WeatherLogBuilder SetWeatherConditions(string? value)
        {
            _instance.WeatherConditions = value;
            return this;
        }
        public WeatherLogBuilder SetDirections(string? value)
        {
            if (string.IsNullOrWhiteSpace(value))
                return this;
            _instance.Directions = value;
            return this;
        }
    }
}
