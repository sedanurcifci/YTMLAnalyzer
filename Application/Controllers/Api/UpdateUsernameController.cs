using Application.ApiLogic;
using Microsoft.AspNetCore.Mvc;

namespace Application.Controllers.Api
{
    [Route("api/[controller]")]
    [ApiController]
    public class UpdateUsernameController : ControllerBase
    {
        public class UpdateModel
        {
            public int uid;
            public string value;
        }
        private UpdateUsername _username;
        public UpdateUsernameController(UpdateUsername username)
        {
            _username = username;
        }
        [HttpPost]
        public IActionResult Update([FromBody] UpdateModel model)
        {
            return Ok(_username.Execute(model.uid, model.value));
        }
    }
}
