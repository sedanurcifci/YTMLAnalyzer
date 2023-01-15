using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc;

namespace Application.Controllers
{
	public class SignoutController : Controller
	{
		public async Task<IActionResult> Index()
		{
			await HttpContext.SignOutAsync("MyCookieAuth");
			return RedirectToAction("Index", "Home");
		}
	}
}
