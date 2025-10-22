using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace CampusLearn.Infrastructure.Data.Entities;
[Table("passwords")]
public partial class Password
{
    [Column("password_id")]
    public int PasswordId { get; set; }
    [Column("user_email")]
    public string UserEmail { get; set; } = null!;
    [Column("password_hash")]
    public string PasswordHash { get; set; } = null!;

    public virtual User User { get; set; } = null!;
}
