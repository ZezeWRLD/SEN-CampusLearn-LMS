using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace CampusLearn.Infrastructure.Data.Entities;

public partial class Chatbotquery
{
    [Column("chatbot_query_id")]
    public int ChatbotQueryId { get; set; }
    [Column("user_email")]
    public string? UserEmail { get; set; }
    [Column("chatbot_query_text")]
    public string ChatbotQueryText { get; set; } = null!;
    [Column("chatbot_response_text")]
    public string? ChatbotResponseText { get; set; }
    
    public virtual User? UserEmailNavigation { get; set; }
}
