using HighSchool.Domain.Common;
using HighSchool.Domain.Errors;

namespace HighSchool.Domain.Entities;

public class StudentAttendance {
    public Guid Id { get; private set; }
    public Guid StudentId { get; private set; }
    public Guid CourseId { get; private set; }
    public DateOnly Date { get; private set; }
    public string Status { get; private set; } = string.Empty;
    public Guid RecordedBy { get; private set; }
    public string? Note { get; private set; }

    private StudentAttendance () {}

    private StudentAttendance (Guid id, Guid studentId, Guid courseId, DateOnly date, string status, Guid recordedBy, string? note)
    {
        Id = id;
        StudentId = studentId;
        CourseId = courseId;
        Date = date;
        Status = status;
        RecordedBy = recordedBy;
        Note = note ?? "";
    }
    public static Result<StudentAttendance> Create(Guid id, Guid studentId, Guid courseId, DateOnly date, string status, Guid recordedBy, string? note)
    {
        if (id == Guid.Empty) return StudentAttendanceErrors.EmptyId;
        if (studentId == Guid.Empty) return StudentAttendanceErrors.EmptyStudentId;
        if (courseId == Guid.Empty) return StudentAttendanceErrors.EmptyCourseId;
        if (string.IsNullOrWhiteSpace(status)) return StudentAttendanceErrors.EmptyStatus;
        if (recordedBy == Guid.Empty) return StudentAttendanceErrors.EmptyRecordedBy;
        return new StudentAttendance(id, studentId, courseId, date, status, recordedBy, note);
    }

    public Result Update(Guid studentId, Guid courseId, DateOnly? date, string status, Guid recordedBy, string? note)
    {
        if (studentId == Guid.Empty) return StudentAttendanceErrors.EmptyStudentId;
        if (courseId == Guid.Empty) return StudentAttendanceErrors.EmptyCourseId;
        if (string.IsNullOrWhiteSpace(status)) return StudentAttendanceErrors.EmptyStatus;
        if (recordedBy == Guid.Empty) return StudentAttendanceErrors.EmptyRecordedBy;
        StudentId = studentId;
        CourseId = courseId;
        if (date != null) Date = date.Value;
        Status = status;
        RecordedBy = recordedBy;
        if (note != null) Note = note;
        return Result.Success();
    }
}