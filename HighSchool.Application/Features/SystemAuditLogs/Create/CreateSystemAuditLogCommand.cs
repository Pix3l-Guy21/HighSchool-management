using HighSchool.Application.Common.Interfaces;

namespace HighSchool.Application.Features.SystemAuditLogs.Create;

public sealed record CreateSystemAuditLogCommand(
    Guid UserId,
    string Action,
    string Details,
    DateTime Timestamp
) : ICommand<Guid>;