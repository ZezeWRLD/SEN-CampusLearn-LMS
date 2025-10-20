using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace CampusLearn.Infrastructure.Data.Entities;

public partial class Resource
{
    [Column("resource_id")]
    public int ResourceId { get; set; }
    [Column("resource_type")]
    public string ResourceType { get; set; } = null!;
    [Column("resource_url")]
    public string ResourceUrl { get; set; } = null!;
    [Column("topic_id")]
    public int? TopicId { get; set; }
    
    public virtual Topic? Topic { get; set; }
}
