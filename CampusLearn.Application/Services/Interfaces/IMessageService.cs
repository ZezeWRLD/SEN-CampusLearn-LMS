using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CampusLearn.Infrastructure.Data.Entities;

namespace CampusLearn.Application.Services.Interfaces
{
    public interface IMessageService
    {
        Task<IEnumerable<Message>> GetAllAsync();
        Task<Message?> GetByIdAsync(int id);
        Task<Message> CreateAsync(Message message);
        Task<Message?> UpdateAsync(int id, Message updatedMessage);
        Task<bool> DeleteAsync(int id);
    }
}
