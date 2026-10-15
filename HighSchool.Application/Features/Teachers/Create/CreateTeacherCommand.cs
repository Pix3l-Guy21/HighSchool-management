using HighSchool.Application.Common.Interfaces;

namespace HighSchool.Application.Features.Teachers.Create;

public sealed record CreateTeacherCommand(
    Guid UserId,
    Guid DepartmentId,
    DateTime HireDate
) : ICommand<Guid>;