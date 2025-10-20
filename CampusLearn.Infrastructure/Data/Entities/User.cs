using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace CampusLearn.Infrastructure.Data.Entities;

public partial class User
{
    [Column("user_id")]
    public int UserId { get; set; }
    [Column("user_email")]
    public string UserEmail { get; set; } = null!;
    [Column("user_name")]
    public string UserName { get; set; } = null!;
    [Column("course_id")]
    public int? CourseId { get; set; }

    public virtual ICollection<Answer> Answers { get; set; } = new List<Answer>();

    public virtual ICollection<Chatbotquery> Chatbotqueries { get; set; } = new List<Chatbotquery>();

    public virtual Course? Course { get; set; }

    public virtual ICollection<Message> Messages { get; set; } = new List<Message>();

    public virtual Notificationpreference? Notificationpreference { get; set; }

    public virtual ICollection<Notification> Notifications { get; set; } = new List<Notification>();

    public virtual ICollection<Question> Questions { get; set; } = new List<Question>();

    public virtual ICollection<Thread> ThreadStudents { get; set; } = new List<Thread>();

    public virtual ICollection<Thread> ThreadTutors { get; set; } = new List<Thread>();

    public virtual ICollection<Tutorassignment> Tutorassignments { get; set; } = new List<Tutorassignment>();

    public virtual ICollection<Vote> Votes { get; set; } = new List<Vote>();

    public virtual ICollection<Role> Roles { get; set; } = new List<Role>();

    public virtual ICollection<Topic> Topics { get; set; } = new List<Topic>();
}
