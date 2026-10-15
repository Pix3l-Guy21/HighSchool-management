using HighSchool.Domain.Common;
using HighSchool.Domain.Errors;

namespace HighSchool.Domain.Entities;

public class SystemAuditLog
{
    public Guid Id { get; private set; }
    public Guid UserId { get; private set; }
    public string Action { get; private set; } = string.Empty;
    public string Details { get; private set; } = string.Empty;
    public  DateTime Timestamp { get; private set; }

    private SystemAuditLog() { }

    private SystemAuditLog(Guid id, Guid userId, string action, string details)
    {
        Id = id;
        UserId = userId;
        Action = action;
        Details = details;
        Timestamp = DateTime.Now;
    }

    public static Result<SystemAuditLog> Create(Guid id, Guid userId, string action, string details)
    {
        if (id == Guid.Empty) return SystemAuditLogErrors.EmptyId;
        if (userId == Guid.Empty) return SystemAuditLogErrors.EmptyUserId;
        if (string.IsNullOrWhiteSpace(action)) return SystemAuditLogErrors.EmptyAction;
        if (string.IsNullOrWhiteSpace(details)) return SystemAuditLogErrors.EmptyDetails;
        return new SystemAuditLog(id, userId, action, details);
    }

    public Result Update(string action, string details)
    {
        if (string.IsNullOrWhiteSpace(action)) return SystemAuditLogErrors.EmptyAction;
        if (string.IsNullOrWhiteSpace(details)) return SystemAuditLogErrors.EmptyDetails;
        Action = action;
        Details = details;
        return Result.Success();
    }
}