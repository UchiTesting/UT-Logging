using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using AspNetCore.Models;

namespace AspNetCore.Controllers;

public class HomeController : Controller
{
	private readonly ILogger<HomeController> _logger;

	public HomeController(ILogger<HomeController> logger)
	{
		_logger = logger;
		_logger.LogDebug(1, "NLog injected into HomeController");
	}

	public IActionResult Index()
	{
		_logger.LogInformation("Hello, this is Home controller index!");
		return View();
	}

	public IActionResult Privacy()
	{
		_logger.LogInformation("Hello, this is Home controller privacy info!");
		return View();
	}

	public IActionResult Fail()
	{
		try
		{
			throw new Exception("I am failing on purpose")!;
		}
		catch (Exception e)
		{
			_logger.LogCritical(e, "Failed on purpose");
		}

		return Content("Should have failed.");
	}

	[ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
	public IActionResult Error()
	{
		string requestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier;
		_logger.LogInformation($"Something went wrong in Home controller => {requestId}");
		return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? requestId });
	}
}
