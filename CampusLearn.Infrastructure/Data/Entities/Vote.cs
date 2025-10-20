using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace CampusLearn.Infrastructure.Data.Entities;

public partial class Vote
{
    [Column("user_id")]
    public int UserId { get; set; }
    [Column("answer_id")]
    public int AnswerId { get; set; }
    [Column("vote_type")]
    public string VoteType { get; set; } = null!;
    
    public virtual Answer Answer { get; set; } = null!;
    
    public virtual User User { get; set; } = null!;
}
