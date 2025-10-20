using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace CampusLearn.Infrastructure.Data.Entities;

public partial class Faq
{
    [Column("faq_id")]
    public int FaqId { get; set; }
    [Column("faq_question")]
    public string FaqQuestion { get; set; } = null!;
    [Column("faq_answer")]
    public string FaqAnswer { get; set; } = null!;
    [Column("topic_id")]
    public int? TopicId { get; set; }
    
    public virtual Topic? Topic { get; set; }
}
