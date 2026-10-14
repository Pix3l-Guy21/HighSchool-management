using HighSchool.Domain.Common;

namespace HighSchool.Domain.Entities;

public class SystemAuditLog
{
    public Guid Id { get; private set; }
    public Guid UserId { get; private set; }
    public string Action { get; private set; } = string.Empty;
    public string Details { get; private set; } = string.Empty;
    public  DateTime Timestamp { get; private set; }

    private SystemAuditLog() { }

    private SystemAuditLog(Guid id, string action, string details)
    {
        Id = id;
        Action = action;
        Details = details;
        Timestamp = DateTime.Now;
    }

    public static Result<SystemAuditLog> Create(Guid id, string action, string details)
    {
        if (id == Guid.Empty) return new Error("SystemAuditLog.EmptyId", "SystemAuditLog Id cannot be empty.", ErrorType.Conflict);
        if (string.IsNullOrWhiteSpace(action)) return new Error("SystemAuditLog.EmptyAction", "System Log action cannot be empty.", ErrorType.Conflict);
        if (string.IsNullOrWhiteSpace(details)) return new Error("SystemAuditLog.EmptyDetails", "System Log details cannot be empty.", ErrorType.Conflict);
        return new SystemAuditLog(id, action, details);
    }

    public Result Update(string action, string details)
    {
        if (string.IsNullOrWhiteSpace(action)) return new Error("SystemAuditLog.EmptyAction", "System Log action cannot be empty.", ErrorType.Conflict);
        if (string.IsNullOrWhiteSpace(details)) return new Error("SystemAuditLog.EmptyDetails", "System Log details cannot be empty.", ErrorType.Conflict);
        Action = action;
        Details = details;
        return Result.Success();
    }
}