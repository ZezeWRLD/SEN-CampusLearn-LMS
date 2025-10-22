using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CampusLearn.Infrastructure.Data.Entities;

namespace CampusLearn.Application.Services.Interfaces
{
    internal interface ITopicService
    {
        Task<IEnumerable<Topic>> GetAllAsync();
        Task<Topic?> GetByIdAsync(int id);
        Task<Topic> CreateAsync(Topic topic);
        Task<Topic?> UpdateAsync(int id, Topic updatedTopic);
        Task<bool> DeleteAsync(int id);
    }
}
