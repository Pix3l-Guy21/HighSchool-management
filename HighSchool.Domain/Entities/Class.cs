using HighSchool.Domain.Common;
using HighSchool.Domain.Errors;

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
        if (id == Guid.Empty) return ClassErrors.EmptyId;
        if (string.IsNullOrWhiteSpace(name)) return ClassErrors.EmptyName;
        if (string.IsNullOrWhiteSpace(academicYear)) return ClassErrors.EmptyAcademicYear;
        if (homeRoomTeacherId == Guid.Empty) return ClassErrors.EmptyHomeRoomTeacherId;
        return new Class(id, name, academicYear, homeRoomTeacherId);
    }

    public Result Update(string name, string academicYear, Guid? homeRoomTeacherId = null)
    {
        if(string.IsNullOrWhiteSpace(name)) return ClassErrors.EmptyName;
        if(string.IsNullOrWhiteSpace(academicYear)) return ClassErrors.EmptyAcademicYear;
        Name = name;
        AcademicYear = academicYear;
        if(homeRoomTeacherId != null) HomeRoomTeacherId = homeRoomTeacherId.Value;
        return Result.Success();
    }
}