using System;
using System.Collections.Generic;

namespace SPSS.BusinessObject.Dtos.ChatHistory;

public class ChatHistoryDto
{
    public Guid Id { get; set; }
    
    public Guid UserId { get; set; }
    
    public string MessageContent { get; set; }
    
    public string SenderType { get; set; }
    
    public DateTimeOffset Timestamp { get; set; }
    
    public string SessionId { get; set; }
}

public class ChatHistoryForCreationDto
{
    public Guid UserId { get; set; }
    
    public string MessageContent { get; set; }
    
    public string SenderType { get; set; }
    
    public string SessionId { get; set; }
}