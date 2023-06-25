using MoscowWeather.Host.Contracts;
using MoscowWeather.Host.Domain;
using NPOI.SS.UserModel;
using NPOI.XSSF.UserModel;
using Throw;
using static MoscowWeather.Host.Domain.WeatherLog;

namespace MoscowWeather.Host.Services;

public class DataExtractService : IDataExtractService
{
    public List<WeatherLog> GetData(Stream exelFileStream)
    {
        var totalLogs = new List<WeatherLog>();
        var workbook = new XSSFWorkbook(exelFileStream);
        for (int i = 0; i < workbook.NumberOfSheets; i++)
        {
            var sheet = workbook.GetSheetAt(i);
            var sheetLogs = FillSheetLogs(sheet);
            totalLogs.AddRange(sheetLogs);
        }
        return totalLogs;
    }

    private List<WeatherLog> FillSheetLogs(ISheet sheet)
    {
        var logs = new List<WeatherLog>();
        for (int row = 4; row <= sheet.LastRowNum; row++)
        {
            var currentRow = sheet.GetRow(row);
            if (currentRow == null) continue;
            var logBuilder = new WeatherLogBuilder();
            try
            {
                for (int column = 0; column < currentRow.LastCellNum; column++)
                {
                    var cellValue = currentRow.GetCell(column);
                    SetProperty(logBuilder, column, cellValue);
                }
                logs.Add(logBuilder.Build());
            }
            catch (Exception ex)
            {
                throw new InvalidDataException($"Sheet: {sheet.SheetName}, Row: {row} Error: {ex.Message}");
            }
            
        }
        return logs;
    }

    private void SetProperty(WeatherLogBuilder logBuilder, int index, ICell cell)
    {
        switch (index)
        {
            case 0:
                logBuilder.SetDay(cell.ToString().ThrowIfNull("Day cell").IfEmpty());
                break;
            case 1:
                logBuilder.SetTime(cell.ToString().ThrowIfNull("Time cell").IfEmpty());
                break;
            case 2:
                logBuilder.SetTemperature(cell.ToString().ThrowIfNull("Temperature cell").IfEmpty());
                break;
            case 3:
                logBuilder.SetRelativeHumidity(cell.ToString().ThrowIfNull("Relative humidity cell").IfEmpty());
                break;
            case 4:
                logBuilder.SetDewPoint(cell.ToString().ThrowIfNull("Dew point cell").IfEmpty());
                break;
            case 5:
                logBuilder.SetAtmospherePressure(cell.ToString().ThrowIfNull("Atmosphere pressure cell").IfEmpty());
                break;
            case 6:
                logBuilder.SetDirections(cell.ToString());
                break;
            case 7:
                logBuilder.SetWindSpeed(cell.ToString());
                break;
            case 8:
                logBuilder.SetCloudiness(cell.ToString());
                break;
            case 9:
                logBuilder.SetCloudBase(cell.ToString());
                break;
            case 10:
                logBuilder.SetHorizontalVisibility(cell.ToString());
                break;
            case 11:
                logBuilder.SetWeatherConditions(cell.ToString());
                break;
            default:
                throw new NotImplementedException();
        }
    }

}