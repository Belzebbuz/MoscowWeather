namespace MoscowWeather.Host.Models;

public class ImportArchivesModel
{
    public string? ErrorMessage { get; private set; }
    public bool Success { get; private set; }

    public static ImportArchivesModel SuccessAction() => new ImportArchivesModel() { Success = true };
    public static ImportArchivesModel Error(string message) => new ImportArchivesModel() { ErrorMessage = message };
}
