using Application.ApiLogic;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Application.Controllers.Api
{
    [Route("api/[controller]")]
    [ApiController]
    public class UpdatePasswordController : ControllerBase
    {
        public class UpdateModel
        {
            public int uid;
            public string value;
        }
        private UpdatePassword _password;
        public UpdatePasswordController(UpdatePassword password)
        {
            _password = password;
        }
        [HttpPost]
        public IActionResult Update([FromBody] UpdateModel model)
        {
            _password.Execute(model.uid, model.value);
            return Ok();
        }
    }
}
