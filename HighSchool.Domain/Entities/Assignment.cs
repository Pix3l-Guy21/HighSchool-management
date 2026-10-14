using HighSchool.Domain.Common;
using HighSchool.Domain.Errors;

namespace HighSchool.Domain.Entities;

public class Assignment
{
    public Guid Id { get; private set; }
    public Guid CourseId { get; private set; }
    public Guid TeacherId { get; private set; }
    public string Title { get; private set; } = string.Empty;   
    public string? Description { get; private set; }   
    public float TotalPoint { get; private set; }
    public DateOnly DueDate { get; private set; }   

    private Assignment() { }

    private Assignment(Guid id, Guid courseId, Guid teacherId, string title, string? description, float? totalPoint, DateOnly dueDate)
    {
        // Validate(id, courseId, teacherId, title, dueDate);

        Id = id;
        CourseId = courseId;
        TeacherId = teacherId;
        Title = title;
        Description = description ?? "No description";
        TotalPoint = totalPoint ?? 0;
        DueDate = dueDate;
    }

    public static Result<Assignment> Create (Guid id, Guid courseId, Guid teacherId, string title, string? description, float? totalPoint, DateOnly? dueDate)
    {
        if (id == Guid.Empty)
            return AssignmentErrors.EmptyId;
        if (courseId == Guid.Empty)
            return AssignmentErrors.EmptyCourseId;
        if (teacherId == Guid.Empty)
            return AssignmentErrors.EmptyTeacherId;
        if (string.IsNullOrWhiteSpace(title))
            return AssignmentErrors.EmptyTitle;
        if (dueDate == null)
            return AssignmentErrors.EmptyDueDate;
        
        return new Assignment(id, courseId, teacherId, title, description, totalPoint, dueDate.Value);
    }

    public Result Update(Guid? courseId, Guid? teacherId, string? title, string? description, float? totalPoint, DateOnly? dueDate)
    {
        if (courseId != null) CourseId = courseId.Value;
        if (teacherId != null) TeacherId = teacherId.Value;
        if (title != null) Title = title;
        if (description != null) Description = description;
        if (totalPoint != null) TotalPoint = totalPoint.Value;
        if (dueDate != null) DueDate = dueDate.Value;

        return Result.Success();
    }
    
}