using HighSchool.Domain.Common;
using HighSchool.Domain.Errors;

namespace HighSchool.Domain.Entities;

public class AdminCommunication
{
    public Guid Id { get; private set; }
    public Guid SenderId { get; private set; }
    public Guid RecipientId { get; private set; }
    public string Subject { get; private set; } = string.Empty;   
    public string Message { get; private set; } = string.Empty;
    public bool IsRead { get; private set; } = false;
    public DateTime SentAt { get; private set; }   

    private AdminCommunication() { }

    private AdminCommunication(Guid id, Guid senderId, Guid recipientId, string subject, string message)
    {
        Id = id;
        SenderId = senderId;
        RecipientId = recipientId;
        Subject = subject;
        Message = message;
        SentAt = DateTime.Now;
    }

    public static Result<AdminCommunication> Create(Guid id, Guid senderId, Guid recipientId, string subject, string message)
    {
        if (id == Guid.Empty) return AdminCommunicationErrors.EmptyId;
        if (senderId == Guid.Empty) return AdminCommunicationErrors.EmptySenderId;
        if (recipientId == Guid.Empty) return AdminCommunicationErrors.EmptyRecipientId;
        if (string.IsNullOrWhiteSpace(subject)) return AdminCommunicationErrors.EmptySubject;
        if (string.IsNullOrWhiteSpace(message)) return AdminCommunicationErrors.EmptyMessage;
        return new AdminCommunication(id, senderId, recipientId, subject, message);
    }

    public Result Update(Guid? senderId, Guid? recipientId, string? subject, string? message)
    {
        if (senderId == Guid.Empty) return AdminCommunicationErrors.EmptySenderId;
        if (recipientId == Guid.Empty) return AdminCommunicationErrors.EmptyRecipientId;
        if (subject != null && string.IsNullOrWhiteSpace(subject)) return AdminCommunicationErrors.EmptySubject;
        if (message != null && string.IsNullOrWhiteSpace(message)) return AdminCommunicationErrors.EmptyMessage;
        if (senderId != null) SenderId = senderId.Value;
        if (recipientId != null) RecipientId = recipientId.Value;
        if (subject != null) Subject = subject;
        if (message != null) Message = message;
        return Result.Success();
    }

    public void Read()
    {
        IsRead = true;
    }

    public void UnRead()
    {
        IsRead = false;
    }

}