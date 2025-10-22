using CampusLearn.Infrastructure.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CampusLearn.Application.Services.Interfaces;
using CampusLearn.Infrastructure.Data.Entities;
using Microsoft.EntityFrameworkCore;

namespace CampusLearn.Application.Services.Implementations
{
    public class MessageService : IMessageService
    {
        private readonly CampusLearnDbContext _context;

        public MessageService(CampusLearnDbContext context)
        {
            _context = context;
        }
        public async Task<IEnumerable<Message>> GetAllAsync() => await _context.Messages.ToListAsync();
        public async Task<Message?> GetByIdAsync(int id) => await _context.Messages.FindAsync(id);
        public async Task<Message> CreateAsync(Message message)
        {
            _context.Messages.Add(message);
            await _context.SaveChangesAsync();
            return message;
        }
        public async Task<Message?> UpdateAsync(int id, Message updatedMessage)
        {
            var message = await _context.Messages.FindAsync(id);
            if (message == null) return null;
            message.MessageBody = updatedMessage.MessageBody;
            message.SenderId = updatedMessage.SenderId;
            await _context.SaveChangesAsync();
            return message;
        }
        public async Task<bool> DeleteAsync(int id)
        {
            var message = await _context.Messages.FindAsync(id);
            if (message == null) return false;
            _context.Messages.Remove(message);
            await _context.SaveChangesAsync();
            return true;
        }
    }
}
