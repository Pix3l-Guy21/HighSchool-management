using HighSchool.Application.Common.Interfaces;

namespace HighSchool.Application.Features.Assignments.Create;

public sealed record CreateAssignmentCommand(
    Guid CourseId,
    Guid TeacherId,
    string Title,
    string Description,
    float TotalPoint,
    DateOnly DueDate
) : ICommand<Guid>;