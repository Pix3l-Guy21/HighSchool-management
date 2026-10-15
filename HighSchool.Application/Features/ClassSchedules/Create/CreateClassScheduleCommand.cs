using HighSchool.Application.Common.Interfaces;

namespace HighSchool.Application.Features.ClassSchedules.Create;

public sealed record CreateClassScheduleCommand(
    Guid ClassId,
    Guid CourseId,
    Guid TeacherId,
    DayOfWeek Day,
    TimeOnly StartTime,
    TimeOnly EndTime,
    string Room
) : ICommand<Guid>;