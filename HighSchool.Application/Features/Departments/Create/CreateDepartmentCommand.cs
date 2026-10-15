using HighSchool.Application.Common.Interfaces;

namespace HighSchool.Application.Features.Departments.Create;

public sealed record CreateDepartmentCommand(
    string Name,
    string Description
) : ICommand<Guid>;