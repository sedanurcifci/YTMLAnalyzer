using Application.ClientLogic;
using Application.Models;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc;
using System.Net;
using System.Security.Claims;

namespace Application.Controllers
{
	public class SigninController : Controller
	{
		private APIClient _client;
		public SigninController(APIClient client)
		{
			_client = client;
		}

		public IActionResult Index()
		{
			return View();
		}

		[HttpPost]
		[ValidateAntiForgeryToken]
		public async Task<ActionResult> Index(SigninModel model)
		{
			if (ModelState.IsValid)
			{
				var result = await _client.SigninUser(model);
				ViewBag.Result = result;
				if (result == "-1")
				{
					return View(model);
				}
				else
				{
					var user = _client.GetUser(Int32.Parse(result)).Result;

					if (user.IsAdmin)
					{
						var claims = new List<Claim>()
				{
					new Claim(ClaimTypes.Name, user.Username),
					new Claim(ClaimTypes.Email, user.EMail),
                    new Claim(ClaimTypes.Role, "Admin"),
					new Claim("UID", result),
                    new Claim("User", "POWER"),
                };
						var identity = new ClaimsIdentity(claims, "MyCookieAuth");
						ClaimsPrincipal claimPrincipal = new ClaimsPrincipal(identity);
						var properties = new AuthenticationProperties
						{
							IsPersistent = true
						};
						await HttpContext.SignInAsync("MyCookieAuth", claimPrincipal, properties);
					}
					else
					{
						var claims = new List<Claim>()
				{
					new Claim(ClaimTypes.Name, user.Username),
					new Claim(ClaimTypes.Email, user.EMail),
					new Claim(ClaimTypes.Role, "User"),
                    new Claim("UID", result),
                    new Claim("User", "Standart"),
				};
						var identity = new ClaimsIdentity(claims, "MyCookieAuth");
						ClaimsPrincipal claimPrincipal = new ClaimsPrincipal(identity);
						var properties = new AuthenticationProperties
						{
							IsPersistent = true
						};
						await HttpContext.SignInAsync("MyCookieAuth", claimPrincipal, properties);
					}
					return RedirectToAction("Index", "Home", null);
				}
			}

			return View(model);
		}
	}
}
