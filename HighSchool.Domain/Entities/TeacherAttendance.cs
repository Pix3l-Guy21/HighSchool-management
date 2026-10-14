using HighSchool.Domain.Common;
using HighSchool.Domain.Errors;

namespace HighSchool.Domain.Entities;

public class TeacherAttendance
{
    public Guid Id { get; private set; }
    public Guid TeacherId { get; private set; }
    public DateOnly Date { get; private set; }
    public string Status { get; private set; } = string.Empty;
    public TimeOnly CheckInTime { get; private set; }
    public TimeOnly CheckOutTime { get; private set; }

    private TeacherAttendance() { }

    private TeacherAttendance(Guid id, Guid teacherId, DateOnly date, string status, TimeOnly checkInTime, TimeOnly checkOutTime)
    {
        Id = id;
        TeacherId = teacherId;
        Status = status;
        Date = date;
        CheckInTime = checkInTime;
        CheckOutTime = checkOutTime;
    }

    public static Result<TeacherAttendance> Create(Guid id, Guid teacherId, DateOnly date, string status, TimeOnly checkInTime, TimeOnly checkOutTime)
    {
        if (id == Guid.Empty) return TeacherAttendanceErrors.EmptyId;
        if (teacherId == Guid.Empty) return TeacherAttendanceErrors.EmptyTeacherId;
        if (string.IsNullOrWhiteSpace(status)) return TeacherAttendanceErrors.EmptyStatus;
        return new TeacherAttendance(id, teacherId, date, status, checkInTime, checkOutTime);
    }

    public Result Update(Guid teacherId, DateOnly? date, string status, TimeOnly? checkInTime, TimeOnly? checkOutTime)
    {
        if(teacherId == Guid.Empty) return TeacherAttendanceErrors.EmptyTeacherId;
        if(string.IsNullOrWhiteSpace(status)) return TeacherAttendanceErrors.EmptyStatus;
        TeacherId = teacherId;
        if(date != null) Date = date.Value;
        Status = status;
        if(checkInTime != null) CheckInTime = checkInTime.Value;
        if(checkOutTime != null) CheckOutTime = checkOutTime.Value;
        return Result.Success();
    }
}