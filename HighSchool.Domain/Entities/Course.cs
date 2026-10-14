using HighSchool.Domain.Common;

namespace HighSchool.Domain.Entities;

public class Course
{
    public Guid Id { get; private set; }
    public string Name { get; private set; } = string.Empty;
    public string Code { get; private set; } = string.Empty;
    public Guid DepartmentId { get; private set; }
    public string? Description { get; private set; }

    private Course () {}

    private Course (Guid id, string name, string code, Guid departmentId, string? description)
    {
        Id = id;
        Name = name;
        Code = code;
        DepartmentId = departmentId;
        Description = description;
    }

    public static Result<Course> Create(Guid id, string name, string code, Guid departmentId, string? description)
    {
        if(id == Guid.Empty) return new Error("Course.EmptyId", "Course Id cannot be empty.", ErrorType.Conflict);
        if(string.IsNullOrWhiteSpace(name)) return new Error("Course.EmptyName", "Course Name cannot be empty.", ErrorType.Conflict);
        if(string.IsNullOrWhiteSpace(code)) return new Error("Course.EmptyCode", "Course Code cannot be empty.", ErrorType.Conflict);
        if(departmentId == Guid.Empty) return new Error("Course.EmptyDepartmentId", "Department Id cannot be empty.", ErrorType.Conflict);
        return new Course(id, name, code, departmentId, description);
    }

    public Result Update(string name, string code, Guid departmentId, string? description)
    {
        if(string.IsNullOrWhiteSpace(name)) return new Error("Course.EmptyName", "Course Name cannot be empty.", ErrorType.Conflict);
        if(string.IsNullOrWhiteSpace(code)) return new Error("Course.EmptyCode", "Course Code cannot be empty.", ErrorType.Conflict);
        if(departmentId == Guid.Empty) return new Error("Course.EmptyDepartmentId", "Department Id cannot be empty.", ErrorType.Conflict);
        Name = name;
        Code = code;
        DepartmentId = departmentId;
        Description = description;
        return Result.Success();
    }
}