using HighSchool.Application.Common.Interfaces;

namespace HighSchool.Application.Features.StudentGrades.Create;

public sealed record CreateStudentGradeCommand(
    Guid StudentId,
    Guid CourseId,
    Guid AssignmentId,
    Guid AssessmentId,
    string Title,
    string Feedback,
    float Score,
    DateOnly GradedDate
) : ICommand<Guid>;