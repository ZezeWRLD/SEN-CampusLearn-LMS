using CampusLearn.Application.Services.Interfaces;
using CampusLearn.Infrastructure.Data.Entities;
using Microsoft.AspNetCore.Mvc;

namespace CampusLearn.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AnswersController : ControllerBase
    {
        private readonly IAnswerService _service;

        public AnswersController(IAnswerService service)
        {
            _service = service;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll() => Ok(await _service.GetAllAsync());

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var answer = await _service.GetByIdAsync(id);
            return answer == null ? NotFound() : Ok(answer);
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] Answer answer)
        {
            var created = await _service.CreateAsync(answer);
            return CreatedAtAction(nameof(GetById), new { id = created.AnswerId }, created);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, [FromBody] Answer answer)
        {
            var updated = await _service.UpdateAsync(id, answer);
            return updated == null ? NotFound() : Ok(updated);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var result = await _service.DeleteAsync(id);
            return result ? NoContent() : NotFound();
        }
    }
}
