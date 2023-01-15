using Application.ApiLogic;
using Application.Models.API;
using Microsoft.AspNetCore.Mvc;

namespace Application.Controllers.Api
{
	[Route("api/[controller]")]
	[ApiController]
	public class SigninController : ControllerBase
	{
		private readonly ILogger<SignupController> _logger;
		private readonly SigninUser _signin;

		public SigninController(ILogger<SignupController> logger, SigninUser signin)
		{
			_logger = logger;
			_signin = signin;
		}

		[HttpPost]
		public IActionResult Signin([FromBody] SigninUserAPIModel model)
		{
			if (model == null
				|| String.IsNullOrEmpty(model.Username)
				|| String.IsNullOrEmpty(model.Password))
				return BadRequest();

			return Ok(_signin.Execute(model));
		}
	}
}
