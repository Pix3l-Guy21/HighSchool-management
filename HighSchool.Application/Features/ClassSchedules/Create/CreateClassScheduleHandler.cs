using HighSchool.Application.Common.Interfaces;
using HighSchool.Domain.Common;
using HighSchool.Domain.Entities;

namespace HighSchool.Application.Features.ClassSchedules.Create;

public sealed class CreateClassScheduleHandler : ICommandHandler<CreateClassScheduleCommand, Guid>
{
  private readonly IClassScheduleRepository _classScheduleRepository;
  private readonly IUnitOfWork _unitOfWork;

  public CreateClassScheduleHandler(
    IClassScheduleRepository classScheduleRepository,
    IUnitOfWork unitOfWork)
  {
    _classScheduleRepository = classScheduleRepository;
    _unitOfWork = unitOfWork;
  }
  public async Task<Result<Guid>> Handle(
    CreateClassScheduleCommand command,
    CancellationToken cancellationToken)
  {
    var classScheduleResult = ClassSchedule.Create(
      Guid.NewGuid(),
      command.ClassId,
      command.CourseId,
      command.TeacherId,
      command.Day,
      command.StartTime,
      command.EndTime,
      command.Room
    );
    if (!classScheduleResult.IsSuccess) return classScheduleResult.Error!;

    var classSchedule = classScheduleResult.Value;

    await _classScheduleRepository.AddAsync(classSchedule, cancellationToken);
    await _unitOfWork.SaveChangesAsync(cancellationToken);
    return classSchedule.Id;
  }
}