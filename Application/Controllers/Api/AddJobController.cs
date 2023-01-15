using Application.ApiLogic;
using Application.Models;
using Microsoft.AspNetCore.Mvc;

namespace Application.Controllers.Api
{
    [Route("api/[controller]")]
    [ApiController]
    public class AddJobController : ControllerBase
    {
        private AddJob _addJob;
        public AddJobController(AddJob addJob)
        {
            _addJob = addJob;
        }
        [HttpPost]
        public IActionResult Update([FromBody] HomeModel model)
        {
            _addJob.Execute(model.uid, model.Job);
            return Ok();
        }
    }
}
