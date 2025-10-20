using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace CampusLearn.Infrastructure.Data.Entities;

public partial class Message
{
    [Column("message_id")]
    public int MessageId { get; set; }
    [Column("message_body")]
    public string MessageBody { get; set; } = null!;
    [Column("thread_id")]
    public int? ThreadId { get; set; }
    [Column("sender_id")]
    public int? SenderId { get; set; }
  
    public virtual User? Sender { get; set; }
   
    public virtual Thread? Thread { get; set; }
}
