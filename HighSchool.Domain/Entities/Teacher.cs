using HighSchool.Domain.Common;

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
        if(id == Guid.Empty) return new Error("Teacher.EmptyId", "Teacher Id cannot be empty.", ErrorType.Conflict);
        if(userId == Guid.Empty) return new Error("Teacher.EmptyUserId", "User Id cannot be empty.", ErrorType.Conflict);
        if(departmentId == Guid.Empty) return new Error("Teacher.EmptyDepartmentId", "Department Id cannot be empty.", ErrorType.Conflict);
        return new Teacher(id, userId, departmentId);
    }

    public Result Update(Guid userId, Guid departmentId)
    {
        if(userId == Guid.Empty) return new Error("Teacher.EmptyUserId", "User Id cannot be empty.", ErrorType.Conflict);
        if(departmentId == Guid.Empty) return new Error("Teacher.EmptyDepartmentId", "Department Id cannot be empty.", ErrorType.Conflict);
        UserId = userId;
        DepartmentId = departmentId;
        return Result.Success();
    }
}