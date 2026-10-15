using HighSchool.Application.Common.Interfaces;

namespace HighSchool.Application.Features.Assessments.Create;

public sealed record CreateAssessmentCommand(
    Guid CourseId,
    Guid TeacherId,
    string Title,
    string? Type,
    float? Weight,
    DateOnly? Date
) : ICommand<Guid>;