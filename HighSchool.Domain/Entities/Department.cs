using HighSchool.Domain.Common;
using HighSchool.Domain.Errors;

namespace HighSchool.Domain.Entities;

public class Department
{
    public Guid Id { get; private set; }
    public string Name { get; private set; } = string.Empty;
    public string? Description {get; private set; }

    private Department (){}
    private Department (Guid id, string name, string? description = null)
    {
        Id = id;
        Name = name;
        Description = description;
    }
    public static Result<Department> Create(Guid id, string name, string? description = null)
    {
        if (id == Guid.Empty) return DepartmentErrors.EmptyId;
        if (string.IsNullOrWhiteSpace(name)) return DepartmentErrors.EmptyName;
        return new Department(id, name, description);
    }

    public Result Update(string name,string? description = null)
    {
        if (string.IsNullOrWhiteSpace(name)) return DepartmentErrors.EmptyName;
        Name = name;
        if (!string.IsNullOrWhiteSpace(description)) Description = description;
        return Result.Success();
    }
}