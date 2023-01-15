using Application.ApiLogic;
using Application.Models.API;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Application.Controllers.Api
{
	[Route("api/[controller]")]
	[ApiController]
	public class GetUserController : ControllerBase
	{
		private GetUser _getuser;
		public GetUserController(GetUser user)
		{
			_getuser = user;
		}
		[HttpPost]
		public IActionResult GetUser([FromBody] int uid)
		{
			if (uid == -1)
				return BadRequest();
			return Ok(_getuser.Execute(uid));
		}
	}
}
