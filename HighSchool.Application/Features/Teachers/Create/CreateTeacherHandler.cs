using HighSchool.Application.Common.Interfaces;
using HighSchool.Domain.Common;
using HighSchool.Domain.Entities;

namespace HighSchool.Application.Features.Teachers.Create;

public sealed class CreateTeacherHandler : ICommandHandler<CreateTeacherCommand, Guid>
{
  private readonly ITeacherRepository _teacherRepository;
  private readonly IUnitOfWork _unitOfWork;

  public CreateTeacherHandler(
    ITeacherRepository teacherRepository,
    IUnitOfWork unitOfWork)
  {
    _teacherRepository = teacherRepository;
    _unitOfWork = unitOfWork;
  }
  public async Task<Result<Guid>> Handle(
    CreateTeacherCommand command,
    CancellationToken cancellationToken)
  {
    var teacherResult = Teacher.Create(
      Guid.NewGuid(),
      command.UserId,
      command.DepartmentId
    );
    if (!teacherResult.IsSuccess) return teacherResult.Error!;

    var teacher = teacherResult.Value;

    await _teacherRepository.AddAsync(teacher, cancellationToken);
    await _unitOfWork.SaveChangesAsync(cancellationToken);
    return teacher.Id;
  }
}