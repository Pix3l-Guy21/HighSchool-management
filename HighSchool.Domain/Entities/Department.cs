using HighSchool.Domain.Common;

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
        if (id == Guid.Empty) return new Error("Department.EmptyId", "Department Id cannot be empty.", ErrorType.Conflict);
        if (string.IsNullOrWhiteSpace(name)) return new Error("Department.EmptyName", "Department Name cannot be empty.", ErrorType.Conflict);
        return new Department(id, name, description);
    }

    public Result Update(string name,string? description = null)
    {
        if (string.IsNullOrWhiteSpace(name)) return new Error("Department.EmptyName", "Department Name cannot be empty.", ErrorType.Conflict);
        Name = name;
        if (!string.IsNullOrWhiteSpace(description)) Description = description;
        return Result.Success();
    }
}