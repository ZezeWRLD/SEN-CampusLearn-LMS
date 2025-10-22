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
    public class NotificationService : INotificationService
    {
        private readonly CampusLearnDbContext _context;

        public NotificationService(CampusLearnDbContext context)
        {
            _context = context;
        }
        public async Task<IEnumerable<Notification>> GetAllNotificationsAsync() => await _context.Notifications.ToListAsync();
        public async Task<Notification> GetNotificationAsync(int id)
        {
            var notification = await _context.Notifications.FindAsync(id);
            if (notification == null)
                throw new InvalidOperationException($"Notification with id {id} not found.");
            return notification;
        }
        public async Task<Notification> CreateNotificationAsync(Notification notification)
        {
            _context.Notifications.Add(notification);
            await _context.SaveChangesAsync();
            return notification;
        }
        public async Task<Notification?> UpdateNotificationAsync(int id, Notification updatedNotification)
        {
            var notification = await _context.Notifications.FindAsync(id);
            if (notification == null) return null;
            notification.NotificationBody = updatedNotification.NotificationBody;
            notification.UserEmailNavigation = updatedNotification.UserEmailNavigation;
            await _context.SaveChangesAsync();
            return notification;
        }
        public async Task<bool> DeleteNotificationAsync(int id)
        {
            var notification = await _context.Notifications.FindAsync(id);
            if (notification == null) return false;
            _context.Notifications.Remove(notification);
            await _context.SaveChangesAsync();
            return true;
        }

    }
}
