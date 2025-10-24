using Microsoft.AspNetCore.Mvc;
using TaskManagerAPI.Services;

namespace TaskManagerAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class TasksController : ControllerBase
    {
        private readonly TaskService _service;
        public TasksController(TaskService service) => _service = service;

        [HttpGet]
        public IActionResult GetAll() => Ok(_service.GetAll());

        [HttpPost]
        public IActionResult Add([FromBody] TaskRequest request)
        {
            if (string.IsNullOrWhiteSpace(request.Description))
                return BadRequest("Description required");

            var added = _service.Add(request.Description);
            return Ok(added);
        }

        [HttpPatch("{id}")]
        public IActionResult Toggle(int id)
        {
            var updated = _service.Toggle(id);
            return updated == null ? NotFound() : Ok(updated);
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
            => _service.Delete(id) ? NoContent() : NotFound();
    }

    public record TaskRequest(string Description);
}
