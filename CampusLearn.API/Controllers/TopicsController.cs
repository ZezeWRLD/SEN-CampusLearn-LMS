using CampusLearn.Application.Services.Interfaces;
using CampusLearn.Infrastructure.Data.Entities;
using Microsoft.AspNetCore.Mvc;

namespace CampusLearn.API.Controllers
{

    [ApiController]
    [Route("api/[controller]")]
    public class TopicsController : ControllerBase
    {
        private readonly ITopicService _service;

        public TopicsController(ITopicService service)
        {
            _service = service;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll() => Ok(await _service.GetAllAsync());

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var topic = await _service.GetByIdAsync(id);
            return topic == null ? NotFound() : Ok(topic);
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] Topic topic)
        {
            var created = await _service.CreateAsync(topic);
            return CreatedAtAction(nameof(GetById), new { id = created.TopicId }, created);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, [FromBody] Topic topic)
        {
            var updated = await _service.UpdateAsync(id, topic);
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
