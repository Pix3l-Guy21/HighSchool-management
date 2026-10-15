using HighSchool.Application.Common.Interfaces;
using HighSchool.Domain.Common;
using HighSchool.Domain.Entities;

namespace HighSchool.Application.Features.Students.Create;

public sealed class CreateStudentHandler : ICommandHandler<CreateStudentCommand, Guid>
{
  private readonly IStudentRepository _studentRepository;
  private readonly IUnitOfWork _unitOfWork;

  public CreateStudentHandler(
    IStudentRepository studentRepository,
    IUnitOfWork unitOfWork)
  {
    _studentRepository = studentRepository;
    _unitOfWork = unitOfWork;
  }
  public async Task<Result<Guid>> Handle(
    CreateStudentCommand command,
    CancellationToken cancellationToken)
  {
    var studentResult = Student.Create(
      Guid.NewGuid(),
      command.UserId,
      command.ClassId,
      command.EnrollementDate
    );
    if (!studentResult.IsSuccess) return studentResult.Error!;

    var student = studentResult.Value;

    await _studentRepository.AddAsync(student, cancellationToken);
    await _unitOfWork.SaveChangesAsync(cancellationToken);
    return student.Id;
  }
}