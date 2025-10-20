using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace CampusLearn.Infrastructure.Data.Entities;

public partial class Answer
{
    [Column("answer_id")]
    public int AnswerId { get; set; }
    [Column("answer_body")]
    public string AnswerBody { get; set; } = null!;
    [Column("question_id")]
    public int? QuestionId { get; set; }
    [Column("user_email")]
    public string? UserEmail { get; set; }
    
    public virtual Question? Question { get; set; }
    
    public virtual User? UserEmailNavigation { get; set; }
    
    public virtual ICollection<Vote> Votes { get; set; } = new List<Vote>();
}
