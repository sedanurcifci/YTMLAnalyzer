using Application.ClientLogic;
using Application.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace Application.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private APIClient _client;

        public HomeController(ILogger<HomeController> logger, APIClient client)
        {
            _logger = logger;
            _client = client;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }
        [HttpPost]
		public async Task<ActionResult> Index(HomeModel model)
        {
            var uid = User.Claims.FirstOrDefault(e => e.Type == "UID").Value;
            await _client.AnalyzIt(Convert.ToInt32(uid), model.Job);
            if(User.IsInRole("User"))
				return RedirectToAction("Index", "User");
            else if(User.IsInRole("Admin"))
				return RedirectToAction("Index", "Admin");
            else
                return View();
		}

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}