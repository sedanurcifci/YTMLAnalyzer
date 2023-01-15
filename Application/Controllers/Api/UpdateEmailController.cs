using Application.ApiLogic;
using Microsoft.AspNetCore.Mvc;

namespace Application.Controllers.Api
{
    [Route("api/[controller]")]
    [ApiController]
    public class UpdateEmailController : ControllerBase
    {
        public class UpdateModel
        {
            public int uid;
            public string value;
        }
        private UpdateEmail _email;
        public UpdateEmailController(UpdateEmail email)
        {
            _email = email;
        }
        [HttpPost]
        public IActionResult Update([FromBody] UpdateModel model)
        {
            return Ok(_email.Execute(model.uid, model.value));
        }
    }
}
