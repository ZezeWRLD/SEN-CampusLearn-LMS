using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace CampusLearn.Infrastructure.Data.Entities;

public partial class Module
{
    [Column("module_code")]
    public string ModuleCode { get; set; } = null!;
    [Column("module_name")]
    public string ModuleName { get; set; } = null!;
 
    public virtual ICollection<Topic> Topics { get; set; } = new List<Topic>();
}
