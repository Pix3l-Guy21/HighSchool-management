using HighSchool.Application.Common.Interfaces;

namespace HighSchool.Application.Features.TeacherAttendances.Create;

public sealed record CreateTeacherAttendanceCommand(
    Guid TeacherId,
    DateOnly Date,
    string Status,
    TimeOnly CheckInTime,
    TimeOnly CheckOutTime
) : ICommand<Guid>;