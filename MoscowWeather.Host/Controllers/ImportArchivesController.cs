using Microsoft.AspNetCore.Mvc;
using MoscowWeather.Host.Contracts;
using MoscowWeather.Host.Models;

namespace MoscowWeather.Host.Controllers;

public class ImportArchivesController : Controller
{
    private readonly IDataExtractService _dataExtractService;
    private readonly ILogger<ImportArchivesController> _logger;
    private readonly IWeatherRepository _weatherRepository;

    public ImportArchivesController(
        IDataExtractService importService, 
        ILogger<ImportArchivesController> logger, 
        IWeatherRepository weatherRepository)
    {
        _dataExtractService = importService;
        _logger = logger;
        _weatherRepository = weatherRepository;
    }
    public IActionResult Index()
    {
        return View(new ImportArchivesModel());
    }

    public async Task<IActionResult> ImportData([FromForm] List<IFormFile> files)
    {
        try
        {
            foreach (IFormFile file in files)
            {
                if(!string.Equals(Path.GetExtension(file.FileName), ".xlsx", StringComparison.OrdinalIgnoreCase))
					return View("Index", ImportArchivesModel.Error("Only .xlsx files available!"));
				using (var stream = file.OpenReadStream())
                {
                    var logs = _dataExtractService.GetData(stream);
                    if(logs.Any())
                        await _weatherRepository.CreateAsync(logs);
                }
            }
            
            return View("Index",ImportArchivesModel.SuccessAction());
        }
        catch (Exception ex)
        {
            _logger.LogError(ex.ToString());
            return View("Index", ImportArchivesModel.Error(ex.Message));
        }
        
    }
}
