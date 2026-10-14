using HighSchool.Domain.Common;

namespace HighSchool.Domain.Entities;

public class Class
{
    public Guid Id { get; private set; }
    public string Name { get; private set; } = string.Empty;
    public string AcademicYear { get; private set; } = string.Empty;
    public Guid HomeRoomTeacherId { get; private set; }

    private Class () {}

    private Class(Guid id, string name, string academicYear, Guid homeRoomTeacherId)
    {
        Id = id;
        Name = name;
        AcademicYear = academicYear;
        HomeRoomTeacherId = homeRoomTeacherId;
    }

    public static Result<Class> Create(Guid id, string name, string academicYear, Guid homeRoomTeacherId)
    {
        if (id == Guid.Empty) return new Error("Class.EmptyId", "Class Id cannot be empty.", ErrorType.Conflict);
        if (string.IsNullOrWhiteSpace(name)) return new Error("Class.EmptyName", "Class name cannot be empty.", ErrorType.Conflict);
        if (string.IsNullOrWhiteSpace(academicYear)) return new Error("Class.EmptyAcademicYear", "Class academic year cannot be empty.", ErrorType.Conflict);
        if (homeRoomTeacherId == Guid.Empty) return new Error("Class.EmptyHomeRoomTeacherId", "Class home room teacher id cannot be empty.", ErrorType.Conflict);
        return new Class(id, name, academicYear, homeRoomTeacherId);
    }

    public Result Update(string name, string academicYear, Guid? homeRoomTeacherId = null)
    {
        if(string.IsNullOrWhiteSpace(name)) return new Error("Class.EmptyName", "Class name cannot be empty.", ErrorType.Conflict);
        if(string.IsNullOrWhiteSpace(academicYear)) return new Error("Class.EmptyAcademicYear", "Class academic year cannot be empty.", ErrorType.Conflict);
        Name = name;
        AcademicYear = academicYear;
        if(homeRoomTeacherId != null) HomeRoomTeacherId = homeRoomTeacherId.Value;
        return Result.Success();
    }
}