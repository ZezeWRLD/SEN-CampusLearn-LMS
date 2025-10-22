using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CampusLearn.Application.Services.Interfaces;
using CampusLearn.Infrastructure.Data;
using CampusLearn.Infrastructure.Data.Entities;
using Microsoft.EntityFrameworkCore;

namespace CampusLearn.Application.Services.Implementations
{
    internal class CourseService : ICourseService
    {
        private readonly CampusLearnDbContext _context;

        public CourseService(CampusLearnDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Course>> GetAllAsync() => await _context.Courses.ToListAsync();

        public async Task<Course?> GetByIdAsync(int id) => await _context.Courses.FindAsync(id);

        public async Task<Course> CreateAsync(Course course)
        {
            _context.Courses.Add(course);
            await _context.SaveChangesAsync();
            return course;
        }

        public async Task<Course?> UpdateAsync(int id, Course updatedCourse)
        {
            var course = await _context.Courses.FindAsync(id);
            if (course == null) return null;

            course.CourseName = updatedCourse.CourseName;
            course.CourseLevel = updatedCourse.CourseLevel;
            await _context.SaveChangesAsync();
            return course;
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var course = await _context.Courses.FindAsync(id);
            if (course == null) return false;

            _context.Courses.Remove(course);
            await _context.SaveChangesAsync();
            return true;
        }
    }
}
