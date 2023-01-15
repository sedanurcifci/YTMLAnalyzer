using Application.ApiLogic;
using Application.Models.API;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Application.Controllers.Api
{
    [Route("api/[controller]")]
    [ApiController]
    public class SignupController : ControllerBase
    {
        private readonly ILogger<SignupController> _logger;
        private readonly SignupUser _signup;

        public SignupController(ILogger<SignupController> logger, SignupUser signup)
        {
            _logger = logger;
            _signup = signup;
        }

        [HttpPost]
		public IActionResult SignUp([FromBody] SignupUserAPIModel model)
        {
            if(model == null 
                || String.IsNullOrEmpty(model.Username) 
                || String.IsNullOrEmpty(model.Email) 
                || String.IsNullOrEmpty(model.Password))
                return BadRequest();

            return Ok(_signup.Execute(model));
        }
    }
}
