using System;
using System.Collections.Generic;
using System.Threading.Tasks;

using Microsoft.AspNetCore.Mvc;

using Todo.Ports.Entities;
using Todo.Ports.UseCases;

namespace Todo.Api.Features.V1.Controllers
{
    [ApiController]
    [ApiVersion("1")]
    [Route("v{version:apiVersion}/tasks")]
    public class TasksController : ControllerBase
    {
        private readonly ITaskService _service;

        public TasksController(ITaskService service)
        {
            _service = service;
        }

        [HttpGet("{pageNumber}/{pageSize}")]
        public async Task<ActionResult<IEnumerable<ITask>>> List(int pageNumber = 1, int pageSize = 10)
        {
            try
            {
                IEnumerable<ITask> tasks = await _service.List(pageNumber, pageSize);

                return Ok(tasks);
            }
            catch (Exception error)
            {
                return BadRequest(error.Message);
            }
        }

        [HttpPost]
        public async Task<IActionResult> New([FromBody] string description)
        {
            try
            {
                Guid id = await _service.Add(description);

                return Ok(id);
            }
            catch (Exception error)
            {
                return BadRequest(error.Message);
            }
        }

        [HttpPut("{id}/Do")]
        public IActionResult Do(Guid id)
        {
            try
            {
                _service.Do(id);

                return Ok();
            }
            catch (Exception error)
            {
                return BadRequest(error.Message);
            }
        }

        [HttpPut("{id}/Undo")]
        public IActionResult Undo(Guid id)
        {
            try
            {
                _service.Undo(id);

                return Ok();
            }
            catch (Exception error)
            {
                return BadRequest(error.Message);
            }
        }

        [HttpDelete("{id}")]
        public IActionResult Remove(Guid id)
        {
            try
            {
                _service.Remove(id);

                return Ok();
            }
            catch (Exception error)
            {
                return BadRequest(error.Message);
            }
        }
    }
}
