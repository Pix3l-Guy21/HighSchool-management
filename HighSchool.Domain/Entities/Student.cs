using HighSchool.Domain.Common;
using HighSchool.Domain.Errors;

namespace HighSchool.Domain.Entities;

public class Student
{
    public Guid Id { get; private set; }
    public Guid UserId { get; private set; }
    public Guid ClassId { get; private set; }
    public DateTime EnrollementDate { get; private set; }

    private Student() {}

    private Student(Guid id, Guid userId, Guid classId, DateTime? enrollementDate)
    {
        Id = id;
        UserId = userId;
        ClassId = classId;
        EnrollementDate = enrollementDate ?? DateTime.Now;
    }

    public static Result<Student> Create(Guid id, Guid userId, Guid classId, DateTime? enrollementDate = null)
    {
        if(id == Guid.Empty) return StudentErrors.EmptyId;
        if(userId == Guid.Empty) return StudentErrors.EmptyUserId;
        if(classId == Guid.Empty) return StudentErrors.EmptyClassId;
        return new Student(id, userId, classId, enrollementDate);
    }

    public Result Update(Guid userId, Guid classId, DateTime? enrollementDate = null)
    {
        if(userId == Guid.Empty) return StudentErrors.EmptyUserId;
        if(classId == Guid.Empty) return StudentErrors.EmptyClassId;
        UserId = userId;
        ClassId = classId;
        if(enrollementDate != null) EnrollementDate = enrollementDate.Value;
        return Result.Success();
    }
}