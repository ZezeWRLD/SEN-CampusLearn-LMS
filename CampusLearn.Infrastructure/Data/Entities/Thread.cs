using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace CampusLearn.Infrastructure.Data.Entities;

public partial class Thread
{
    [Column("thread_id")]
    public int ThreadId { get; set; }
    [Column("topic_id")]
    public int? TopicId { get; set; }
    [Column("student_id")]
    public int? StudentId { get; set; }
    [Column("tutor_id")]
    public int? TutorId { get; set; }
    [Column("messages")]
    public virtual ICollection<Message> Messages { get; set; } = new List<Message>();
   
    public virtual User? Student { get; set; }
 
    public virtual Topic? Topic { get; set; }
    
    public virtual User? Tutor { get; set; }
}
