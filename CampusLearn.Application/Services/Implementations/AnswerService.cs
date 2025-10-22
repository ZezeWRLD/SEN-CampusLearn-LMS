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
    public class AnswerService : IAnswerService
    {
        private readonly CampusLearnDbContext _context;

        public AnswerService(CampusLearnDbContext context)
        {
            _context = context;
        }
        public async Task<IEnumerable<Answer>> GetAllAsync() => await _context.Answers.ToListAsync();
        public async Task<Answer?> GetByIdAsync(int id) => await _context.Answers.FindAsync(id);
        public async Task<Answer> CreateAsync(Answer answer)
        {
            _context.Answers.Add(answer);
            await _context.SaveChangesAsync();
            return answer;
        }
        public async Task<Answer?> UpdateAsync(int id, Answer updatedAnswer)
        {
            var answer = await _context.Answers.FindAsync(id);
            if (answer == null) return null;
            answer.AnswerBody = updatedAnswer.AnswerBody;
            answer.QuestionId = updatedAnswer.QuestionId;
            answer.UserEmail = updatedAnswer.UserEmail;
            await _context.SaveChangesAsync();
            return answer;
        }
        public async Task<bool> DeleteAsync(int id)
        {
            var answer = await _context.Answers.FindAsync(id);
            if (answer == null) return false;
            _context.Answers.Remove(answer);
            await _context.SaveChangesAsync();
            return true;
        }

    }
}
