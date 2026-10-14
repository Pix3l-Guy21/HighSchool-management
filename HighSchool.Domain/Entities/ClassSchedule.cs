using HighSchool.Domain.Common;
using HighSchool.Domain.Errors;

namespace HighSchool.Domain.Entities;

public class ClassSchedule
{
    public Guid Id { get; private set; }
    public Guid ClassId { get; private set; }
    public Guid CourseId { get; private set; }
    public Guid TeacherId { get; private set; }
    public DayOfWeek Day { get; private set; }
    public TimeOnly StartTime { get; private set; }
    public TimeOnly EndTime { get; private set; }
    public string Room { get; private set; } = string.Empty;


    private ClassSchedule() { }

    private ClassSchedule(Guid id, Guid classId, Guid courseId, Guid teacherId, DayOfWeek day, TimeOnly startTime, TimeOnly endTime, string room)
    {
        Id = id;
        ClassId = classId;
        CourseId = courseId;
        TeacherId = teacherId;
        Day = day;
        StartTime = startTime;
        EndTime = endTime;
        Room = room;
    }

    public static Result<ClassSchedule> Create(Guid id, Guid classId, Guid courseId, Guid teacherId, DayOfWeek day, TimeOnly startTime, TimeOnly endTime, string room)
    {
        if (id == Guid.Empty) return ClassScheduleErrors.EmptyId;
        if (classId == Guid.Empty) return ClassScheduleErrors.EmptyClassId;
        if (courseId == Guid.Empty) return ClassScheduleErrors.EmptyCourseId;
        if (teacherId == Guid.Empty) return ClassScheduleErrors.EmptyTeacherId;
        if (string.IsNullOrWhiteSpace(room)) return ClassScheduleErrors.EmptyRoom;
        if (endTime <= startTime) return ClassScheduleErrors.InvalidTimeRange;
        return new ClassSchedule(id, classId, courseId, teacherId, day, startTime, endTime, room);
    }

    public Result Update(Guid classId, Guid courseId, Guid teacherId, DayOfWeek? day, TimeOnly? startTime, TimeOnly? endTime, string room)
    {
        if (classId == Guid.Empty) return ClassScheduleErrors.EmptyClassId;
        if (courseId == Guid.Empty) return ClassScheduleErrors.EmptyCourseId;
        if (teacherId == Guid.Empty) return ClassScheduleErrors.EmptyTeacherId;
        if (string.IsNullOrWhiteSpace(room)) return ClassScheduleErrors.EmptyRoom;
        if (startTime != null && endTime != null && endTime <= startTime) return ClassScheduleErrors.InvalidTimeRange;
        ClassId = classId;
        CourseId = courseId;
        TeacherId = teacherId;
        if (day != null) Day = day.Value;
        if (startTime != null) StartTime = startTime.Value;
        if (endTime != null) EndTime = endTime.Value;
        Room = room;
        return Result.Success();
    }
}