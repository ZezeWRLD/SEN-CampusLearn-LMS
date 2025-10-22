using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CampusLearn.Infrastructure.Data.Entities;

namespace CampusLearn.Application.Services.Interfaces
{
    public interface INotificationService
    {
        Task<Notification> GetNotificationAsync(int id);
        Task<IEnumerable<Notification>> GetAllNotificationsAsync();
        Task<Notification> CreateNotificationAsync(Notification notification);

        Task<Notification?> UpdateNotificationAsync(int id, Notification updatedNotification);  
        Task<bool> DeleteNotificationAsync(int id);
        Task SendSmsAsync(string to, string message);
        Task SendWhatsappAsync(string to, string message);
        Task SendEmailAsync(string to, string subject, string body);
    }
}
