using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CampusLearn.Infrastructure.Data.Entities;

namespace CampusLearn.Application.Services.Interfaces
{
    public interface IAnswerService
    {
        Task<IEnumerable<Answer>> GetAllAsync();
        Task<Answer?> GetByIdAsync(int id);
        Task<Answer> CreateAsync(Answer answer);
        Task<Answer?> UpdateAsync(int id, Answer updatedAnswer);
        Task<bool> DeleteAsync(int id);
    }
}
