using HighSchool.Application.Common.Interfaces;

namespace HighSchool.Application.Features.Students.Create;

public sealed record CreateStudentCommand(
    Guid UserId,
    Guid ClassId,
    DateTime EnrollementDate
) : ICommand<Guid>;