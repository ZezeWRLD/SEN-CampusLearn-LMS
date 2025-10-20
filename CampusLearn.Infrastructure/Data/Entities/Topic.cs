using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace CampusLearn.Infrastructure.Data.Entities;

public partial class Topic
{
    [Column("topic_id")]
    public int TopicId { get; set; }
    [Column("topic_title")]
    public string TopicTitle { get; set; } = null!;
    [Column("module_code")]
    public string? ModuleCode { get; set; }
    
    public virtual ICollection<Faq> Faqs { get; set; } = new List<Faq>();
  
    public virtual Module? ModuleCodeNavigation { get; set; }
    
    public virtual ICollection<Question> Questions { get; set; } = new List<Question>();
    
    public virtual ICollection<Resource> Resources { get; set; } = new List<Resource>();
   
    public virtual ICollection<Thread> Threads { get; set; } = new List<Thread>();
   
    public virtual ICollection<User> Users { get; set; } = new List<User>();
}
