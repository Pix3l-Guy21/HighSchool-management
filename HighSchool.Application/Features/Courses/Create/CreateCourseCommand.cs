using HighSchool.Application.Common.Interfaces;

namespace HighSchool.Application.Features.Courses.Create;

public sealed record CreateCourseCommand(
    string Name,
    string Code,
    Guid DepartmentId,
    string Description
) : ICommand<Guid>;