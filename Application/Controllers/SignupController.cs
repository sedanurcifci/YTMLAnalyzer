using Application.ClientLogic;
using Application.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Application.Controllers
{
    public class SignupController : Controller
    {
        private APIClient _client;
        public SignupController(APIClient client) 
        { 
            _client = client;
        }
        // GET: SignupController
        public ActionResult Index()
        {
            ViewBag.Register = false;
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Index(SignupModel model)
        {
            if(ModelState.IsValid)
            {
                var result = await _client.CreateUser(model);
				ViewBag.Result = result;
				if (result == "1")
                {
                    ViewBag.Register = true;
                }
                else
                {
					ViewBag.Register = false;
				}
				return View(model);
			}

            return View(model);
        }
    }
}
