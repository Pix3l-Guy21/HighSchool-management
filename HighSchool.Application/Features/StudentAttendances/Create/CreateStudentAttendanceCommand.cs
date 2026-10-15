using HighSchool.Application.Common.Interfaces;

namespace HighSchool.Application.Features.StudentAttendances.Create;

public sealed record CreateStudentAttendanceCommand(
    Guid StudentId,
    Guid CourseId,
    DateOnly Date,
    string Status,
    Guid RecordedBy,
    string Note
) : ICommand<Guid>;