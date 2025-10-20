using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace CampusLearn.Infrastructure.Data.Entities;

public partial class Notificationpreference
{
    [Column("user_id")]
    public int UserId { get; set; }
    [Column("email_enabled")]
    public bool? EmailEnabled { get; set; }
    [Column("whatsapp_enabled")]
    public bool? WhatsappEnabled { get; set; }
   
    public virtual User User { get; set; } = null!;
}
