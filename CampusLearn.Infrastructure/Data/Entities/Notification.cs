using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace CampusLearn.Infrastructure.Data.Entities;

public partial class Notification
{
    [Column("notification_id")]
    public int NotificationId { get; set; }
    [Column("user_email")]
    public string? UserEmail { get; set; }
    [Column("notification_type")]
    public string NotificationType { get; set; } = null!;
    [Column("notification_status")]
    public string? NotificationStatus { get; set; }

    public virtual User? UserEmailNavigation { get; set; }
}
