using HighSchool.Domain.Common;

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
        if (id == Guid.Empty) return new Error("AdminCommunication.EmptyId", "AdminCommunication Id cannot be empty.", ErrorType.Conflict);
        if (senderId == Guid.Empty) return new Error("AdminCommunication.EmptySenderId", "Sender Id cannot be empty.", ErrorType.Conflict);
        if (recipientId == Guid.Empty) return new Error("AdminCommunication.EmptyRecipientId", "Recipient Id cannot be empty.", ErrorType.Conflict);
        if (string.IsNullOrWhiteSpace(subject)) return new Error("AdminCommunication.EmptySubject", "AdminCommunication Subject cannot be empty.", ErrorType.Conflict);
        if (string.IsNullOrWhiteSpace(message)) return new Error("AdminCommunication.EmptyMessage", "AdminCommunication Message cannot be empty.", ErrorType.Conflict);
        return new AdminCommunication(id, senderId, recipientId, subject, message);
    }

    public Result Update(Guid? senderId, Guid? recipientId, string? subject, string? message)
    {
        if (senderId == Guid.Empty) return new Error("AdminCommunication.EmptySenderId", "Sender Id cannot be empty.", ErrorType.Conflict);
        if (recipientId == Guid.Empty) return new Error("AdminCommunication.EmptyRecipientId", "Recipient Id cannot be empty.", ErrorType.Conflict);
        if (subject != null && string.IsNullOrWhiteSpace(subject)) return new Error("AdminCommunication.EmptySubject", "AdminCommunication Subject cannot be empty.", ErrorType.Conflict);
        if (message != null && string.IsNullOrWhiteSpace(message)) return new Error("AdminCommunication.EmptyMessage", "AdminCommunication Message cannot be empty.", ErrorType.Conflict);
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