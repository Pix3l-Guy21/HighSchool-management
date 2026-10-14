using HighSchool.Domain.Common;

namespace HighSchool.Domain.Entities;

public class StudentComment
{
    public Guid Id { get; private set; }
    public Guid StudentId { get; private set; }
    public Guid TeacherId { get; private set; }
    public string CommentText { get; private set; } = string.Empty;   
    public string? Type { get; private set; }   
    public DateTime CreatedAt { get; private set; }   

    private StudentComment() { }

    private StudentComment(Guid id, Guid studentId, Guid teacherId, string commentText, string? type)
    {
        Id = id;
        StudentId = studentId;
        TeacherId = teacherId;
        CommentText = commentText;
        Type = type ?? "No type";
        CreatedAt = DateTime.Now;
    }

    public static Result<StudentComment> Create(Guid id, Guid studentId, Guid teacherId, string commentText, string? type)
    {
        if (id == Guid.Empty) return new Error("StudentComment.EmptyId", "StudentComment Id cannot be empty.", ErrorType.Conflict);
        if (studentId == Guid.Empty) return new Error("StudentComment.EmptyStudentId", "Student Id cannot be empty.", ErrorType.Conflict);
        if (teacherId == Guid.Empty) return new Error("StudentComment.EmptyTeacherId", "Teacher Id cannot be empty.", ErrorType.Conflict);
        if (string.IsNullOrWhiteSpace(commentText)) return new Error("StudentComment.EmptyCommentText", "StudentComment CommentText cannot be empty.", ErrorType.Conflict);
        return new StudentComment(id, studentId, teacherId, commentText, type);
    }

    public Result Update(Guid? studentId, Guid? teacherId, string? commentText, string? type)
    {
        if (studentId == Guid.Empty) return new Error("StudentComment.EmptyStudentId", "Student Id cannot be empty.", ErrorType.Conflict);
        if (teacherId == Guid.Empty) return new Error("StudentComment.EmptyTeacherId", "Teacher Id cannot be empty.", ErrorType.Conflict);
        if (commentText != null && string.IsNullOrWhiteSpace(commentText)) return new Error("StudentComment.EmptyCommentText", "StudentComment CommentText cannot be empty.", ErrorType.Conflict);
        if (studentId != null) StudentId = studentId.Value;
        if (teacherId != null) TeacherId = teacherId.Value;
        if (commentText != null) CommentText = commentText;
        if (type != null) Type = type;
        return Result.Success();
    }
}