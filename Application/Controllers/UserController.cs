using Application.ClientLogic;
using Application.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Application.Controllers
{
    [Authorize(Policy = "User")]
    public class UserController : Controller
    {
        private APIClient _client;
        public UserController(APIClient client)
        {
            _client = client;
        }

        public async Task<ActionResult> Index()
        {
            var model = new UserModel();
			var uid = User.Claims.FirstOrDefault(e => e.Type == "UID").Value;
			model.Jobs = await _client.GetUserJobs(Convert.ToInt32(uid));
            return View(model);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Index(int id, [FromBody]UserModel model)
        {
            if(model.UpdateType == 1)
            {
                //UserName
                var uid = User.Claims.FirstOrDefault(e => e.Type == "UID").Value;
                var result = await _client.UpdateUsername(Convert.ToInt32(uid), model.Username);
                if (Convert.ToInt32(result) == -1) ViewBag.ErrorCode = -1;
				if (Convert.ToInt32(result) == -2) ViewBag.ErrorCode = -2;

			}
            else if(model.UpdateType == 2)
            {
                //Password
                var uid = User.Claims.FirstOrDefault(e => e.Type == "UID").Value;
                var result = await _client.UpdateUsername(Convert.ToInt32(uid), model.Password);

            }
            else if(model.UpdateType == 3)
            {
                //Email
                var uid = User.Claims.FirstOrDefault(e => e.Type == "UID").Value;
                var result = await _client.UpdateUsername(Convert.ToInt32(uid), model.EMail);
				if (Convert.ToInt32(result) == -1) ViewBag.ErrorCode = -1;
				if (Convert.ToInt32(result) == -2) ViewBag.ErrorCode = -2;
			}
            return Ok(model);
        }
    }
}
