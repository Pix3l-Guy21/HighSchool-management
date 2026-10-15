using HighSchool.Domain.Entities;

namespace HighSchool.Application.Common.Interfaces;

public interface ISystemAuditLogRepository
{
   Task AddAsync(
      SystemAuditLog systemAuditLog,
      CancellationToken cancellationToken);

   Task<Assessment?> GetByIdAsync(
      Guid systemAuditLogId,
      CancellationToken cancellationToken);
}