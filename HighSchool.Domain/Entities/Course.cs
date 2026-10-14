using HighSchool.Domain.Common;
using HighSchool.Domain.Errors;

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
        if(id == Guid.Empty) return CourseErrors.EmptyId;
        if(string.IsNullOrWhiteSpace(name)) return CourseErrors.EmptyName;
        if(string.IsNullOrWhiteSpace(code)) return CourseErrors.EmptyCode;
        if(departmentId == Guid.Empty) return CourseErrors.EmptyDepartmentId;
        return new Course(id, name, code, departmentId, description);
    }

    public Result Update(string name, string code, Guid departmentId, string? description)
    {
        if(string.IsNullOrWhiteSpace(name)) return CourseErrors.EmptyName;
        if(string.IsNullOrWhiteSpace(code)) return CourseErrors.EmptyCode;
        if(departmentId == Guid.Empty) return CourseErrors.EmptyDepartmentId;
        Name = name;
        Code = code;
        DepartmentId = departmentId;
        Description = description;
        return Result.Success();
    }
}