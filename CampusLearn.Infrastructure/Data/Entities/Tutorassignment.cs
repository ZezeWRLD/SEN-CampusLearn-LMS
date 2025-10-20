using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace CampusLearn.Infrastructure.Data.Entities;

public partial class Tutorassignment
{
    [Column("assignment_id")]
    public int AssignmentId { get; set; }
    [Column("question_id")]
    public int? QuestionId { get; set; }
    [Column("tutor_id")]
    public int? TutorId { get; set; }
    
    public virtual Question? Question { get; set; }
   
    public virtual User? Tutor { get; set; }
}
