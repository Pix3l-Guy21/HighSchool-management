using HighSchool.Domain.Common;

namespace HighSchool.Domain.Entities;

public class Assessment
{
    public Guid Id { get; private set; }
    public Guid CourseId { get; private set; }
    public Guid TeacherId { get; private set; }
    public string Title { get; private set; } = string.Empty;   
    public string? Type { get; private set; }   
    public float Weight { get; private set; }
    public DateOnly Date { get; private set; }   

    private Assessment() { }

    private Assessment(Guid id, Guid courseId, Guid teacherId, string title, string? type, float? weight, DateOnly date)
    {
        Id = id;
        CourseId = courseId;
        TeacherId = teacherId;
        Title = title;
        Type = type ?? "No type";
        Weight = weight ?? 0;
        Date = date;
    }

    public static Result<Assessment> Create (Guid id, Guid courseId, Guid teacherId, string title, string? type, float? weight, DateOnly? date)
    {
        if (id == Guid.Empty)
            return new Error("Assessment.EmptyId", "Assessment Id cannot be empty.", ErrorType.Conflict);
        if (courseId == Guid.Empty)
            return new Error("Assessment.EmptyCourseId", "Course Id cannot be empty.", ErrorType.Conflict);
        if (teacherId == Guid.Empty)
            return new Error("Assessment.EmptyTeacherId", "Teacher Id cannot be empty.", ErrorType.Conflict);
        if (string.IsNullOrWhiteSpace(title))
            return new Error("Assessment.EmptyTitle", "Assessment Title cannot be empty.", ErrorType.Conflict);
        if (date == null)
            return new Error("Assessment.NullDate", "Assessment date cannot be empty.", ErrorType.Conflict);

        return new Assessment(id, courseId, teacherId, title, type, weight, date.Value);
    }

    public Result Update(Guid? courseId, Guid? teacherId, string? title, string? type, float? weight, DateOnly? date)
    {
        if (title != null && string.IsNullOrWhiteSpace(title))
            return new Error("Assessment.EmptyTitle", "Assessment Title cannot be empty.", ErrorType.Conflict);

        if (courseId != null) CourseId = courseId.Value;
        if (teacherId != null) TeacherId = teacherId.Value;
        if (title != null) Title = title;
        if (type != null) Type = type;
        if (weight != null) Weight = weight.Value;
        if (date != null) Date = date.Value;

        return Result.Success();

    }

    
}