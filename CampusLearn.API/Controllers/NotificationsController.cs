using CampusLearn.Application.Services.Interfaces;
using CampusLearn.Infrastructure.Data.Entities;
using Microsoft.AspNetCore.Mvc;

namespace CampusLearn.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class NotificationsController : ControllerBase
    {
        private readonly INotificationService _service;

        public NotificationsController(INotificationService service)
        {
            _service = service;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll() => Ok(await _service.GetAllNotificationsAsync());

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var notif = await _service.GetNotificationAsync(id);
            return notif == null ? NotFound() : Ok(notif);
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] Notification notif)
        {
            var created = await _service.CreateNotificationAsync(notif);
            return CreatedAtAction(nameof(GetById), new { id = created.NotificationId }, created);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, [FromBody] Notification notif)
        {
            var updated = await _service.UpdateNotificationAsync(id, notif);
            return updated == null ? NotFound() : Ok(updated);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var result = await _service.DeleteNotificationAsync(id);
            return result ? NoContent() : NotFound();
        }
    }
}
