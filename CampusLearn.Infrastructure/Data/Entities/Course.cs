using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace CampusLearn.Infrastructure.Data.Entities;

public partial class Course
{
    [Column("course_id")]
    public int CourseId { get; set; }
    [Column("course_name")]
    public string CourseName { get; set; } = null!;
    [Column("course_level")]
    public string CourseLevel { get; set; } = null!;
   
    public virtual ICollection<User> Users { get; set; } = new List<User>();
}
