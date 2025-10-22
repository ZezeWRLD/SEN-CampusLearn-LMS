using CampusLearn.Infrastructure.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CampusLearn.Application.Services.Interfaces
{
    internal interface ICourseService
    {
        Task<IEnumerable<Course>> GetAllAsync();
        Task<Course?> GetByIdAsync(int id);
        Task<Course> CreateAsync(Course course);
        Task<Course?> UpdateAsync(int id, Course updatedCourse);
        Task<bool> DeleteAsync(int id);
    }
}
