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
    public class TopicService : ITopicService
    {
        private readonly CampusLearnDbContext _context;

        public TopicService(CampusLearnDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Topic>> GetAllAsync() => await _context.Topics.ToListAsync();

        public async Task<Topic?> GetByIdAsync(int id) => await _context.Topics.FindAsync(id);

        public async Task<Topic> CreateAsync(Topic topic)
        {
            _context.Topics.Add(topic);
            await _context.SaveChangesAsync();
            return topic;
        }

        public async Task<Topic?> UpdateAsync(int id, Topic updatedTopic)
        {
            var topic = await _context.Topics.FindAsync(id);
            if (topic == null) return null;

            topic.TopicTitle = updatedTopic.TopicTitle;
            await _context.SaveChangesAsync();
            return topic;
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var topic = await _context.Topics.FindAsync(id);
            if (topic == null) return false;

            _context.Topics.Remove(topic);
            await _context.SaveChangesAsync();
            return true;
        }
    }
}
