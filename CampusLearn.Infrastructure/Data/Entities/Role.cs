using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace CampusLearn.Infrastructure.Data.Entities;

public partial class Role
{
    [Column("role_id")]
    public int RoleId { get; set; }
    [Column("role_name")]
    public string RoleName { get; set; } = null!;
    
    public virtual ICollection<User> UserEmails { get; set; } = new List<User>();
}
