using Microsoft.AspNetCore.Mvc;
using MvcStok.Models;
using MvcStok.Models2;
using System.Diagnostics;

namespace MvcStok.Controllers
{
	public class HomeController : Controller
	{
		private readonly ILogger<HomeController> _logger;
		private readonly MvcDbStokContext mvcDbStokContext;

		public HomeController(ILogger<HomeController> logger, MvcDbStokContext mvcDbStokContext)
		{
			_logger = logger;
			this.mvcDbStokContext = mvcDbStokContext;
		}

		public IActionResult Index()
		{
			return View();
		}

		public IActionResult Privacy()
		{
			return View();
		}

		[ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
		public IActionResult Error()
		{
			return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
		}
	}
}
