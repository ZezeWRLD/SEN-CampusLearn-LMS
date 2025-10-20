using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace CampusLearn.Infrastructure.Data.Entities;

public partial class Question
{
    [Column("question_id")]
    public int QuestionId { get; set; }
    [Column("question_body")]
    public string QuestionBody { get; set; } = null!;
    [Column("question_is_anonymous")]
    public bool QuestionIsAnonymous { get; set; }
    [Column("topic_id")]
    public int? TopicId { get; set; }
    [Column("user_id")]
    public int? UserId { get; set; }
  
    public virtual ICollection<Answer> Answers { get; set; } = new List<Answer>();
  
    public virtual Topic? Topic { get; set; }
 
    public virtual ICollection<Tutorassignment> Tutorassignments { get; set; } = new List<Tutorassignment>();
 
    public virtual User? User { get; set; }
}
