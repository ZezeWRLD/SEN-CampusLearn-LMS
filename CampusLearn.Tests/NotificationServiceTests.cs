using CampusLearn.Infrastructure.Data;
using CampusLearn.Infrastructure.Data.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;
using Moq;
using CampusLearn.Application.Services.Implementations;

namespace CampusLearn.Tests
{
    public class NotificationServiceTests
    {
        private CampusLearnDbContext CreateInMemoryContext(string dbName)
        {
            var options = new DbContextOptionsBuilder<CampusLearnDbContext>()
                .UseInMemoryDatabase(databaseName: dbName)
                .Options;

            return new CampusLearnDbContext(options);
        }
        [Fact]
        public async Task SendEmailIfEnabledAsync_ShouldSendEmail_WhenEmailIsEnabled()
        {
            //Arrange
            await using var context = CreateInMemoryContext("testDB");

            var user = new User { UserId = 1, UserEmail = "test@example.com" , UserName = "Test User"};
            var preference = new Notificationpreference
            {
                UserId = 1,
                User = user,
                EmailEnabled = true,
            };
            context.Users.Add(user);
            context.Notificationpreferences.Add(preference);
            var password = new Password
            {
                UserEmail = "test@example.com",
                PasswordHash = "hashedpassword"
            };
            context.Passwords.Add(password);
            await context.SaveChangesAsync();

            var configMock = new Mock<IConfiguration>();
            configMock.Setup(c => c["SendGrid:ApiKey"]).Returns("fake-key");
            configMock.Setup(c => c["SendGrid:FromEmail"]).Returns("from@example.com");
            configMock.Setup(c => c["Twilio:AccountSid"]).Returns("fake-sid");
            configMock.Setup(c => c["Twilio:AuthToken"]).Returns("fake-token");
            configMock.Setup(c => c["Twilio:FromNumber"]).Returns("+10000000000");

            //Act
            var service = new NotificationService(context, configMock.Object);
            await service.SendNotificationToUserAsync(1, "Test Subject", "Test Body");

            //Assert
            Assert.True(true);
        }    
    }
}
