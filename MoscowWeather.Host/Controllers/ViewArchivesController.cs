using Microsoft.AspNetCore.Mvc;
using MoscowWeather.Host.Contracts;
using MoscowWeather.Host.Models;

namespace MoscowWeather.Host.Controllers;

public class ViewArchivesController : Controller
{
    private readonly IWeatherRepository _weatherRepository;

    public ViewArchivesController(IWeatherRepository weatherRepository)
    {
        _weatherRepository = weatherRepository;
    }

    public async Task<IActionResult> Index()
    {
        var logsResult = await _weatherRepository.GetAsync(null, null, 1, 10);
        var years = await _weatherRepository.GetTotalYearsAsync();
        return View(new ViewArchivesModel() { Result = logsResult, Years = years });
    }

    public async Task<IActionResult> GetData(int? year, int? month, int page)
    {
        var logsResult = await _weatherRepository.GetAsync(year, month, page, 10);
		var years = await _weatherRepository.GetTotalYearsAsync();
        return View("Index", new ViewArchivesModel() { Result = logsResult, Years = years, Query = new(page, year, month) });
	}
}
