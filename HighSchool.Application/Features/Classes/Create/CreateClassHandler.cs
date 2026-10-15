using HighSchool.Application.Common.Interfaces;
using HighSchool.Domain.Common;
using HighSchool.Domain.Entities;

namespace HighSchool.Application.Features.Classes.Create;

public sealed class CreateClassHandler : ICommandHandler<CreateClassCommand, Guid>
{
  private readonly IClassRepository _classRepository;
  private readonly IUnitOfWork _unitOfWork;

  public CreateClassHandler(
    IClassRepository classRepository,
    IUnitOfWork unitOfWork)
  {
    _classRepository = classRepository;
    _unitOfWork = unitOfWork;
  }
  public async Task<Result<Guid>> Handle(
    CreateClassCommand command,
    CancellationToken cancellationToken)
  {
    var classResult = Class.Create(
      Guid.NewGuid(),
      command.Name,
      command.AcademicYear,
      command.HomeRoomTeacherId
    );
    if (!classResult.IsSuccess) return classResult.Error!;

    var classRoom = classResult.Value;

    await _classRepository.AddAsync(classRoom, cancellationToken);
    await _unitOfWork.SaveChangesAsync(cancellationToken);
    return classRoom.Id;
  }
}