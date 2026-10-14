using HighSchool.Domain.Common;
using HighSchool.Domain.Errors;

namespace HighSchool.Domain.Entities;

public class Teacher
{
    public Guid Id { get; private set; }
    public Guid UserId { get; private set; }
    public Guid DepartmentId { get; private set; }
    public DateTime HireDate { get; private set; }

    private Teacher () {}

    private Teacher (Guid id, Guid userId, Guid departmentId)
    {
        Id = id;
        UserId = userId;
        DepartmentId = departmentId;
        HireDate = DateTime.Now;
    }

    public static Result<Teacher> Create(Guid id, Guid userId, Guid departmentId)
    {
        if(id == Guid.Empty) return TeacherErrors.EmptyId;
        if(userId == Guid.Empty) return TeacherErrors.EmptyUserId;
        if(departmentId == Guid.Empty) return TeacherErrors.EmptyDepartmentId;
        return new Teacher(id, userId, departmentId);
    }

    public Result Update(Guid userId, Guid departmentId)
    {
        if(userId == Guid.Empty) return TeacherErrors.EmptyUserId;
        if(departmentId == Guid.Empty) return TeacherErrors.EmptyDepartmentId;
        UserId = userId;
        DepartmentId = departmentId;
        return Result.Success();
    }
}