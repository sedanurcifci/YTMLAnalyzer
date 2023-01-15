using Application.ApiLogic;
using Microsoft.AspNetCore.Mvc;

namespace Application.Controllers.Api
{
	[Route("api/[controller]")]
	[ApiController]
	public class GetUserJobsController : ControllerBase
	{
		public GetUserJobs _getUser;
		public GetUserJobsController(GetUserJobs getUser)
		{
			_getUser = getUser;
		}
		[HttpPost]
		public IActionResult Update([FromBody]int uid)
		{
			return Ok(_getUser.Execute(uid));
		}
	}
}
