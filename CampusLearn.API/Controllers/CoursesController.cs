using CampusLearn.Application.Services.Interfaces;
using CampusLearn.Infrastructure.Data;
using CampusLearn.Infrastructure.Data.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace CampusLearn.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CoursesController : ControllerBase
    {
        private readonly CampusLearnDbContext _context;

        public CoursesController(CampusLearnDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<IEnumerable<Course>> GetAllAsync() =>
            await _context.Courses
                .OrderBy(c => c.CourseName)
                .ToListAsync();

        
        [HttpGet("{id}")]
        public async Task<IActionResult> GetCourseById(int id)
        {
            var course = await _context.Courses.FindAsync(id);

            if (course == null)
                return NotFound($"Course with ID {id} not found.");

            return Ok(course);
        }

        [HttpPost]
        public async Task<IActionResult> CreateCourse([FromBody] Course newCourse)
        {
            if (newCourse == null || string.IsNullOrWhiteSpace(newCourse.CourseName))
                return BadRequest("Invalid course data.");

            _context.Courses.Add(newCourse);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetCourseById), new { id = newCourse.CourseId }, newCourse);
        }

       
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateCourse(int id, [FromBody] Course updatedCourse)
        {
            if (id != updatedCourse.CourseId)
                return BadRequest("Course ID mismatch.");

            var course = await _context.Courses.FindAsync(id);
            if (course == null)
                return NotFound($"Course with ID {id} not found.");

            course.CourseName = updatedCourse.CourseName;
            course.CourseLevel = updatedCourse.CourseLevel;

            _context.Courses.Update(course);
            await _context.SaveChangesAsync();

            return Ok(course);
        }

        
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCourse(int id)
        {
            var course = await _context.Courses.FindAsync(id);
            if (course == null)
                return NotFound($"Course with ID {id} not found.");

            _context.Courses.Remove(course);
            await _context.SaveChangesAsync();

            return Ok($"Course '{course.CourseName}' deleted successfully.");
        }
    }
}
