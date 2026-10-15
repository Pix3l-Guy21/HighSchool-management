using HighSchool.Application.Common.Interfaces;
using HighSchool.Domain.Common;
using HighSchool.Domain.Entities;

namespace HighSchool.Application.Features.TeacherAttendances.Create;

public sealed class CreateTeacherAttendanceHandler : ICommandHandler<CreateTeacherAttendanceCommand, Guid>
{
  private readonly ITeacherAttendanceRepository _teacherAttendanceRepository;
  private readonly IUnitOfWork _unitOfWork;

  public CreateTeacherAttendanceHandler(
    ITeacherAttendanceRepository teacherAttendanceRepository,
    IUnitOfWork unitOfWork)
  {
    _teacherAttendanceRepository = teacherAttendanceRepository;
    _unitOfWork = unitOfWork;
  }
  public async Task<Result<Guid>> Handle(
    CreateTeacherAttendanceCommand command,
    CancellationToken cancellationToken)
  {
    var teacherAttendanceResult = TeacherAttendance.Create(
      Guid.NewGuid(),
      command.TeacherId,
      command.Date,
      command.Status,
      command.CheckInTime,
      command.CheckOutTime
    );
    if (!teacherAttendanceResult.IsSuccess) return teacherAttendanceResult.Error!;

    var teacherAttendance = teacherAttendanceResult.Value;

    await _teacherAttendanceRepository.AddAsync(teacherAttendance, cancellationToken);
    await _unitOfWork.SaveChangesAsync(cancellationToken);
    return teacherAttendance.Id;
  }
}