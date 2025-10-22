using System;
using System.Collections.Generic; 
using CampusLearn.Infrastructure.Data.Entities;
using Microsoft.EntityFrameworkCore;
using Thread = CampusLearn.Infrastructure.Data.Entities.Thread;

namespace CampusLearn.Infrastructure.Data;

public partial class CampusLearnDbContext : DbContext
{
    public CampusLearnDbContext()
    {
    }

    public CampusLearnDbContext(DbContextOptions<CampusLearnDbContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Answer> Answers { get; set; }

    public virtual DbSet<Chatbotquery> Chatbotqueries { get; set; }

    public virtual DbSet<Course> Courses { get; set; }

    public virtual DbSet<Faq> Faqs { get; set; }

    public virtual DbSet<Message> Messages { get; set; }

    public virtual DbSet<Module> Modules { get; set; }

    public virtual DbSet<Notification> Notifications { get; set; }

    public virtual DbSet<Notificationpreference> Notificationpreferences { get; set; }

    public virtual DbSet<Question> Questions { get; set; }

    public virtual DbSet<Resource> Resources { get; set; }

    public virtual DbSet<Role> Roles { get; set; }

    public virtual DbSet<Thread> Threads { get; set; }

    public virtual DbSet<Topic> Topics { get; set; }

    public virtual DbSet<Tutorassignment> Tutorassignments { get; set; }

    public virtual DbSet<User> Users { get; set; }

    public virtual DbSet<Vote> Votes { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseNpgsql(" Host=aws-1-ap-southeast-2.pooler.supabase.com;Port=6543;Database=postgres;Username=postgres.tspbuvfvayujbjxtxngb;Password=3JAyVUlQf3h3O28f;Pooling=false;SSL Mode=Require;Trust Server Certificate=true;Timeout=15;Keepalive=30;");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder
            .HasPostgresEnum("auth", "aal_level", new[] { "aal1", "aal2", "aal3" })
            .HasPostgresEnum("auth", "code_challenge_method", new[] { "s256", "plain" })
            .HasPostgresEnum("auth", "factor_status", new[] { "unverified", "verified" })
            .HasPostgresEnum("auth", "factor_type", new[] { "totp", "webauthn", "phone" })
            .HasPostgresEnum("auth", "oauth_authorization_status", new[] { "pending", "approved", "denied", "expired" })
            .HasPostgresEnum("auth", "oauth_client_type", new[] { "public", "confidential" })
            .HasPostgresEnum("auth", "oauth_registration_type", new[] { "dynamic", "manual" })
            .HasPostgresEnum("auth", "oauth_response_type", new[] { "code" })
            .HasPostgresEnum("auth", "one_time_token_type", new[] { "confirmation_token", "reauthentication_token", "recovery_token", "email_change_token_new", "email_change_token_current", "phone_change_token" })
            .HasPostgresEnum("realtime", "action", new[] { "INSERT", "UPDATE", "DELETE", "TRUNCATE", "ERROR" })
            .HasPostgresEnum("realtime", "equality_op", new[] { "eq", "neq", "lt", "lte", "gt", "gte", "in" })
            .HasPostgresEnum("storage", "buckettype", new[] { "STANDARD", "ANALYTICS" })
            .HasPostgresExtension("extensions", "pg_stat_statements")
            .HasPostgresExtension("extensions", "pgcrypto")
            .HasPostgresExtension("extensions", "uuid-ossp")
            .HasPostgresExtension("graphql", "pg_graphql")
            .HasPostgresExtension("vault", "supabase_vault");

        modelBuilder.Entity<Answer>(entity =>
        {
            entity.HasKey(e => e.AnswerId).HasName("answers_pkey");

            entity.ToTable("answers");

            entity.Property(e => e.AnswerId)
                .UseIdentityAlwaysColumn()
                .HasColumnName("answer_id");
            entity.Property(e => e.AnswerBody).HasColumnName("answer_body");
            entity.Property(e => e.QuestionId).HasColumnName("question_id");
            entity.Property(e => e.UserEmail)
                .HasMaxLength(255)
                .HasColumnName("user_email");

            entity.HasOne(d => d.Question).WithMany(p => p.Answers)
                .HasForeignKey(d => d.QuestionId)
                .OnDelete(DeleteBehavior.Cascade)
                .HasConstraintName("answers_question_id_fkey");

            entity.HasOne(d => d.UserEmailNavigation).WithMany(p => p.Answers)
                .HasPrincipalKey(p => p.UserEmail)
                .HasForeignKey(d => d.UserEmail)
                .OnDelete(DeleteBehavior.SetNull)
                .HasConstraintName("answers_user_email_fkey");
        });

        modelBuilder.Entity<Chatbotquery>(entity =>
        {
            entity.HasKey(e => e.ChatbotQueryId).HasName("chatbotqueries_pkey");

            entity.ToTable("chatbotqueries");

            entity.Property(e => e.ChatbotQueryId)
                .UseIdentityAlwaysColumn()
                .HasColumnName("chatbot_query_id");
            entity.Property(e => e.ChatbotQueryText).HasColumnName("chatbot_query_text");
            entity.Property(e => e.ChatbotResponseText).HasColumnName("chatbot_response_text");
            entity.Property(e => e.UserEmail)
                .HasMaxLength(255)
                .HasColumnName("user_email");

            entity.HasOne(d => d.UserEmailNavigation).WithMany(p => p.Chatbotqueries)
                .HasPrincipalKey(p => p.UserEmail)
                .HasForeignKey(d => d.UserEmail)
                .HasConstraintName("chatbotqueries_user_email_fkey");
        });

        modelBuilder.Entity<Course>(entity =>
        {
            entity.HasKey(e => e.CourseId).HasName("courses_pkey");

            entity.ToTable("courses");

            entity.Property(e => e.CourseId)
                .UseIdentityAlwaysColumn()
                .HasColumnName("course_id");
            entity.Property(e => e.CourseLevel)
                .HasMaxLength(100)
                .HasColumnName("course_level");
            entity.Property(e => e.CourseName)
                .HasMaxLength(255)
                .HasColumnName("course_name");
        });

        modelBuilder.Entity<Faq>(entity =>
        {
            entity.HasKey(e => e.FaqId).HasName("faqs_pkey");

            entity.ToTable("faqs");

            entity.Property(e => e.FaqId)
                .UseIdentityAlwaysColumn()
                .HasColumnName("faq_id");
            entity.Property(e => e.FaqAnswer).HasColumnName("faq_answer");
            entity.Property(e => e.FaqQuestion).HasColumnName("faq_question");
            entity.Property(e => e.TopicId).HasColumnName("topic_id");

            entity.HasOne(d => d.Topic).WithMany(p => p.Faqs)
                .HasForeignKey(d => d.TopicId)
                .OnDelete(DeleteBehavior.SetNull)
                .HasConstraintName("faqs_topic_id_fkey");
        });

        modelBuilder.Entity<Message>(entity =>
        {
            entity.HasKey(e => e.MessageId).HasName("messages_pkey");

            entity.ToTable("messages");

            entity.Property(e => e.MessageId)
                .UseIdentityAlwaysColumn()
                .HasColumnName("message_id");
            entity.Property(e => e.MessageBody).HasColumnName("message_body");
            entity.Property(e => e.SenderId).HasColumnName("sender_id");
            entity.Property(e => e.ThreadId).HasColumnName("thread_id");

            entity.HasOne(d => d.Sender).WithMany(p => p.Messages)
                .HasForeignKey(d => d.SenderId)
                .HasConstraintName("messages_sender_id_fkey");

            entity.HasOne(d => d.Thread).WithMany(p => p.Messages)
                .HasForeignKey(d => d.ThreadId)
                .OnDelete(DeleteBehavior.Cascade)
                .HasConstraintName("messages_thread_id_fkey");
        });

        modelBuilder.Entity<Module>(entity =>
        {
            entity.HasKey(e => e.ModuleCode).HasName("modules_pkey");

            entity.ToTable("modules");

            entity.Property(e => e.ModuleCode)
                .HasMaxLength(20)
                .HasColumnName("module_code");
            entity.Property(e => e.ModuleName)
                .HasMaxLength(255)
                .HasColumnName("module_name");
        });

        modelBuilder.Entity<Notification>(entity =>
        {
            entity.HasKey(e => e.NotificationId).HasName("notifications_pkey");

            entity.ToTable("notifications");

            entity.Property(e => e.NotificationId)
                .UseIdentityAlwaysColumn()
                .HasColumnName("notification_id");
            entity.Property(e => e.NotificationStatus)
                .HasMaxLength(20)
                .HasDefaultValueSql("'unread'::character varying")
                .HasColumnName("notification_status");
            entity.Property(e => e.NotificationType)
                .HasMaxLength(100)
                .HasColumnName("notification_type");
            entity.Property(e => e.UserEmail)
                .HasMaxLength(255)
                .HasColumnName("user_email");
            entity.Property(e => e.NotificationBody)
                .HasMaxLength(255)
                .HasColumnName("notification_body");

            entity.HasOne(d => d.UserEmailNavigation).WithMany(p => p.Notifications)
                .HasPrincipalKey(p => p.UserEmail)
                .HasForeignKey(d => d.UserEmail)
                .OnDelete(DeleteBehavior.Cascade)
                .HasConstraintName("notifications_user_email_fkey");
        });

        modelBuilder.Entity<Notificationpreference>(entity =>
        {
            entity.HasKey(e => e.UserId).HasName("notificationpreference_pkey");

            entity.ToTable("notificationpreference");

            entity.Property(e => e.UserId)
                .ValueGeneratedNever()
                .HasColumnName("user_id");
            entity.Property(e => e.EmailEnabled)
                .HasDefaultValue(true)
                .HasColumnName("email_enabled");
            entity.Property(e => e.WhatsappEnabled)
                .HasDefaultValue(false)
                .HasColumnName("whatsapp_enabled");

            entity.HasOne(d => d.User).WithOne(p => p.Notificationpreference)
                .HasForeignKey<Notificationpreference>(d => d.UserId)
                .HasConstraintName("notificationpreference_user_id_fkey");
        });

        modelBuilder.Entity<Question>(entity =>
        {
            entity.HasKey(e => e.QuestionId).HasName("questions_pkey");

            entity.ToTable("questions");

            entity.Property(e => e.QuestionId)
                .UseIdentityAlwaysColumn()
                .HasColumnName("question_id");
            entity.Property(e => e.QuestionBody).HasColumnName("question_body");
            entity.Property(e => e.QuestionIsAnonymous)
                .HasDefaultValue(false)
                .HasColumnName("question_is_anonymous");
            entity.Property(e => e.TopicId).HasColumnName("topic_id");
            entity.Property(e => e.UserId).HasColumnName("user_id");

            entity.HasOne(d => d.Topic).WithMany(p => p.Questions)
                .HasForeignKey(d => d.TopicId)
                .OnDelete(DeleteBehavior.SetNull)
                .HasConstraintName("questions_topic_id_fkey");

            entity.HasOne(d => d.User).WithMany(p => p.Questions)
                .HasForeignKey(d => d.UserId)
                .OnDelete(DeleteBehavior.SetNull)
                .HasConstraintName("questions_user_id_fkey");
        });

        modelBuilder.Entity<Resource>(entity =>
        {
            entity.HasKey(e => e.ResourceId).HasName("resources_pkey");

            entity.ToTable("resources");

            entity.Property(e => e.ResourceId)
                .UseIdentityAlwaysColumn()
                .HasColumnName("resource_id");
            entity.Property(e => e.ResourceType)
                .HasMaxLength(50)
                .HasColumnName("resource_type");
            entity.Property(e => e.ResourceUrl)
                .HasMaxLength(1000)
                .HasColumnName("resource_url");
            entity.Property(e => e.TopicId).HasColumnName("topic_id");

            entity.HasOne(d => d.Topic).WithMany(p => p.Resources)
                .HasForeignKey(d => d.TopicId)
                .OnDelete(DeleteBehavior.Cascade)
                .HasConstraintName("resources_topic_id_fkey");
        });

        modelBuilder.Entity<Role>(entity =>
        {
            entity.HasKey(e => e.RoleId).HasName("roles_pkey");

            entity.ToTable("roles");

            entity.HasIndex(e => e.RoleName, "roles_role_name_key").IsUnique();

            entity.Property(e => e.RoleId)
                .UseIdentityAlwaysColumn()
                .HasColumnName("role_id");
            entity.Property(e => e.RoleName)
                .HasMaxLength(100)
                .HasColumnName("role_name");
        });

        modelBuilder.Entity<Thread>(entity =>
        {
            entity.HasKey(e => e.ThreadId).HasName("threads_pkey");

            entity.ToTable("threads");

            entity.Property(e => e.ThreadId)
                .UseIdentityAlwaysColumn()
                .HasColumnName("thread_id");
            entity.Property(e => e.StudentId).HasColumnName("student_id");
            entity.Property(e => e.TopicId).HasColumnName("topic_id");
            entity.Property(e => e.TutorId).HasColumnName("tutor_id");

            entity.HasOne(d => d.Student).WithMany(p => p.ThreadStudents)
                .HasForeignKey(d => d.StudentId)
                .HasConstraintName("threads_student_id_fkey");

            entity.HasOne(d => d.Topic).WithMany(p => p.Threads)
                .HasForeignKey(d => d.TopicId)
                .OnDelete(DeleteBehavior.Cascade)
                .HasConstraintName("threads_topic_id_fkey");

            entity.HasOne(d => d.Tutor).WithMany(p => p.ThreadTutors)
                .HasForeignKey(d => d.TutorId)
                .HasConstraintName("threads_tutor_id_fkey");
        });

        modelBuilder.Entity<Topic>(entity =>
        {
            entity.HasKey(e => e.TopicId).HasName("topics_pkey");

            entity.ToTable("topics");

            entity.Property(e => e.TopicId)
                .UseIdentityAlwaysColumn()
                .HasColumnName("topic_id");
            entity.Property(e => e.ModuleCode)
                .HasMaxLength(20)
                .HasColumnName("module_code");
            entity.Property(e => e.TopicTitle)
                .HasMaxLength(255)
                .HasColumnName("topic_title");

            entity.HasOne(d => d.ModuleCodeNavigation).WithMany(p => p.Topics)
                .HasForeignKey(d => d.ModuleCode)
                .OnDelete(DeleteBehavior.SetNull)
                .HasConstraintName("topics_module_code_fkey");

            entity.HasMany(d => d.Users).WithMany(p => p.Topics)
                .UsingEntity<Dictionary<string, object>>(
                    "Topicsubscriber",
                    r => r.HasOne<User>().WithMany()
                        .HasForeignKey("UserId")
                        .HasConstraintName("topicsubscribers_user_id_fkey"),
                    l => l.HasOne<Topic>().WithMany()
                        .HasForeignKey("TopicId")
                        .HasConstraintName("topicsubscribers_topic_id_fkey"),
                    j =>
                    {
                        j.HasKey("TopicId", "UserId").HasName("topicsubscribers_pkey");
                        j.ToTable("topicsubscribers");
                        j.IndexerProperty<int>("TopicId").HasColumnName("topic_id");
                        j.IndexerProperty<int>("UserId").HasColumnName("user_id");
                    });
        });

        modelBuilder.Entity<Tutorassignment>(entity =>
        {
            entity.HasKey(e => e.AssignmentId).HasName("tutorassignments_pkey");

            entity.ToTable("tutorassignments");

            entity.Property(e => e.AssignmentId)
                .UseIdentityAlwaysColumn()
                .HasColumnName("assignment_id");
            entity.Property(e => e.QuestionId).HasColumnName("question_id");
            entity.Property(e => e.TutorId).HasColumnName("tutor_id");

            entity.HasOne(d => d.Question).WithMany(p => p.Tutorassignments)
                .HasForeignKey(d => d.QuestionId)
                .OnDelete(DeleteBehavior.Cascade)
                .HasConstraintName("tutorassignments_question_id_fkey");

            entity.HasOne(d => d.Tutor).WithMany(p => p.Tutorassignments)
                .HasForeignKey(d => d.TutorId)
                .HasConstraintName("tutorassignments_tutor_id_fkey");
        });

        modelBuilder.Entity<User>(entity =>
        {
            entity.HasKey(e => e.UserId).HasName("users_pkey");

            entity.ToTable("users");

            entity.HasIndex(e => e.UserEmail, "users_user_email_key").IsUnique();

            entity.Property(e => e.UserId)
                .UseIdentityAlwaysColumn()
                .HasColumnName("user_id");
            entity.Property(e => e.CourseId).HasColumnName("course_id");
            entity.Property(e => e.UserEmail)
                .HasMaxLength(255)
                .HasColumnName("user_email");
            entity.Property(e => e.UserName)
                .HasMaxLength(255)
                .HasColumnName("user_name");

            entity.HasOne(d => d.Course).WithMany(p => p.Users)
                .HasForeignKey(d => d.CourseId)
                .OnDelete(DeleteBehavior.SetNull)
                .HasConstraintName("users_course_id_fkey");

            entity.HasMany(d => d.Roles).WithMany(p => p.UserEmails)
                .UsingEntity<Dictionary<string, object>>(
                    "Userrole",
                    r => r.HasOne<Role>().WithMany()
                        .HasForeignKey("RoleId")
                        .HasConstraintName("userroles_role_id_fkey"),
                    l => l.HasOne<User>().WithMany()
                        .HasPrincipalKey("UserEmail")
                        .HasForeignKey("UserEmail")
                        .HasConstraintName("userroles_user_email_fkey"),
                    j =>
                    {
                        j.HasKey("UserEmail", "RoleId").HasName("userroles_pkey");
                        j.ToTable("userroles");
                        j.IndexerProperty<string>("UserEmail")
                            .HasMaxLength(255)
                            .HasColumnName("user_email");
                        j.IndexerProperty<int>("RoleId").HasColumnName("role_id");
                    });
        });

        modelBuilder.Entity<Vote>(entity =>
        {
            entity.HasKey(e => new { e.UserId, e.AnswerId }).HasName("votes_pkey");

            entity.ToTable("votes");

            entity.Property(e => e.UserId).HasColumnName("user_id");
            entity.Property(e => e.AnswerId).HasColumnName("answer_id");
            entity.Property(e => e.VoteType)
                .HasMaxLength(10)
                .HasColumnName("vote_type");

            entity.HasOne(d => d.Answer).WithMany(p => p.Votes)
                .HasForeignKey(d => d.AnswerId)
                .HasConstraintName("votes_answer_id_fkey");

            entity.HasOne(d => d.User).WithMany(p => p.Votes)
                .HasForeignKey(d => d.UserId)
                .HasConstraintName("votes_user_id_fkey");
        });
        modelBuilder.Entity<Password>(entity =>
        {
            entity.HasKey(e => e.PasswordId)
                .HasName("passwords_pkey");

            entity.ToTable("passwords");

            entity.Property(e => e.PasswordId)
                .HasColumnName("password_id");

            entity.Property(e => e.UserEmail)
                .HasMaxLength(255)
                .HasColumnName("user_email");

            entity.Property(e => e.PasswordHash)
                .HasMaxLength(255)
                .HasColumnName("password_hash");

            entity.HasIndex(e => e.UserEmail)
                .IsUnique()
                .HasDatabaseName("passwords_user_email_key");

            entity.HasOne(d => d.User)
                .WithOne(p => p.Password)
                .HasForeignKey<Password>(d => d.UserEmail)
                .OnDelete(DeleteBehavior.Cascade)
                .HasConstraintName("fk_user_email");
        });


        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
