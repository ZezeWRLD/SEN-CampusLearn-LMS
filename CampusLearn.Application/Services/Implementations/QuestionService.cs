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
    internal class QuestionService : IQuestionService
    {
        private readonly CampusLearnDbContext _context;

        public QuestionService(CampusLearnDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Question>> GetAllAsync() => await _context.Questions.ToListAsync();

        public async Task<Question?> GetByIdAsync(int id) => await _context.Questions.FindAsync(id);

        public async Task<Question> CreateAsync(Question question)
        {
            _context.Questions.Add(question);
            await _context.SaveChangesAsync();
            return question;
        }

        public async Task<Question?> UpdateAsync(int id, Question updated)
        {
            var question = await _context.Questions.FindAsync(id);
            if (question == null) return null;

            question.QuestionBody = updated.QuestionBody;
            question.QuestionIsAnonymous = updated.QuestionIsAnonymous;
            await _context.SaveChangesAsync();
            return question;
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var question = await _context.Questions.FindAsync(id);
            if (question == null) return false;

            _context.Questions.Remove(question);
            await _context.SaveChangesAsync();
            return true;
        }
    }
}
