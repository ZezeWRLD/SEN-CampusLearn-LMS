using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CampusLearn.Application.Services.Interfaces;
using CampusLearn.Infrastructure.Data;
using CampusLearn.Infrastructure.Data.Entities;
using Microsoft.EntityFrameworkCore;
using Twilio;
using Twilio.Rest.Api.V2010.Account;
using Twilio.Types;
using SendGrid;
using SendGrid.Helpers.Mail;
using Microsoft.Extensions.Configuration;


namespace CampusLearn.Application.Services.Implementations
{
    public class NotificationService : INotificationService
    {
        private readonly CampusLearnDbContext _context;
        private readonly string _twilioSid;
        private readonly string _twilioToken;
        private readonly string _twilioNumber;
        private readonly string _sendgridKey;
        private readonly string _fromEmail;

        public NotificationService(CampusLearnDbContext context, IConfiguration configuration)
        {
            _context = context;
            _twilioSid = configuration["Twilio:AccountSid"]
                ?? throw new InvalidOperationException("Missing Twilio AccountSid");
            _twilioToken = configuration["Twilio:AuthToken"]
                ?? throw new InvalidOperationException("Missing Twilio AuthToken");
            _twilioNumber = configuration["Twilio:FromNumber"]
                ?? throw new InvalidOperationException("Missing Twilio FromNumber");
            _sendgridKey = configuration["SendGrid:ApiKey"]
                ?? throw new InvalidOperationException("Missing SendGrid ApiKey");
            _fromEmail = configuration["SendGrid:FromEmail"]
                ?? throw new InvalidOperationException("Missing SendGrid FromEmail");

            TwilioClient.Init(_twilioSid, _twilioToken);
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
        public async Task SendNotificationToUserAsync(int userId, string subject, string message)
        {
            var preference = await _context.Notificationpreferences
                .FindAsync(userId);
            if (preference == null) 
                throw new InvalidOperationException($"No notification preferences found for user {userId}");
            var user = preference.User;
            if (preference.EmailEnabled == true)
            {
                await SendEmailAsync(user.UserEmail, subject, message);
            }
            else
            {
                await SendEmailAsync (user.UserEmail, subject, message);
            }
        }
        public async Task SendSmsAsync(string to, string message) //unused. Just here for future expansion and to show future implementation
        {
            await MessageResource.CreateAsync(
                body: message,
                from: new PhoneNumber(_twilioNumber),
                to: new PhoneNumber(to)
                );
        }
        public async Task SendWhatsappAsync(string to, string message) //unused. Just here for future expansion and to show future implementation
        {
            await MessageResource.CreateAsync(
                body: message,
                from: new PhoneNumber("whatsapp:+14155238886"),
                to: new PhoneNumber($"whatsapp:{to}")
                );
        }
        public async Task SendEmailAsync(string to, string subject, string body)
        {
            SendGridClient client = new SendGridClient(_sendgridKey);
            EmailAddress emailAddress = new EmailAddress(_fromEmail, "CampusLearn");
            string htmlBody = $"<p>{body}</p>";
            SendGridMessage msg = MailHelper.CreateSingleEmail(emailAddress, new EmailAddress(to), subject, body, htmlBody);
            Response response = await client.SendEmailAsync(msg);

        }

    }
}
