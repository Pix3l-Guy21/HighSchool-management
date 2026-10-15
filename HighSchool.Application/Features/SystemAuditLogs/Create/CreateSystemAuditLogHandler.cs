using HighSchool.Application.Common.Interfaces;
using HighSchool.Domain.Common;
using HighSchool.Domain.Entities;

namespace HighSchool.Application.Features.SystemAuditLogs.Create;

public sealed class CreateSystemAuditLogHandler : ICommandHandler<CreateSystemAuditLogCommand, Guid>
{
  private readonly ISystemAuditLogRepository _systemAuditLogRepository;
  private readonly IUnitOfWork _unitOfWork;

  public CreateSystemAuditLogHandler(
    ISystemAuditLogRepository systemAuditLogRepository,
    IUnitOfWork unitOfWork)
  {
    _systemAuditLogRepository = systemAuditLogRepository;
    _unitOfWork = unitOfWork;
  }
  public async Task<Result<Guid>> Handle(
    CreateSystemAuditLogCommand command,
    CancellationToken cancellationToken)
  {
    var systemAuditLogResult = SystemAuditLog.Create(
      Guid.NewGuid(),
      command.UserId,
      command.Action,
      command.Details
    );
    if (!systemAuditLogResult.IsSuccess) return systemAuditLogResult.Error!;

    var systemAuditLog = systemAuditLogResult.Value;

    await _systemAuditLogRepository.AddAsync(systemAuditLog, cancellationToken);
    await _unitOfWork.SaveChangesAsync(cancellationToken);
    return systemAuditLog.Id;
  }
}