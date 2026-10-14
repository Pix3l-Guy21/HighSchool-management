using HighSchool.Domain.Common;
using HighSchool.Domain.Errors;

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
        if (id == Guid.Empty) return StudentCommentErrors.EmptyId;
        if (studentId == Guid.Empty) return StudentCommentErrors.EmptyStudentId;
        if (teacherId == Guid.Empty) return StudentCommentErrors.EmptyTeacherId;
        if (string.IsNullOrWhiteSpace(commentText)) return StudentCommentErrors.EmptyCommentText;
        return new StudentComment(id, studentId, teacherId, commentText, type);
    }

    public Result Update(Guid? studentId, Guid? teacherId, string? commentText, string? type)
    {
        if (studentId == Guid.Empty) return StudentCommentErrors.EmptyStudentId;
        if (teacherId == Guid.Empty) return StudentCommentErrors.EmptyTeacherId;
        if (commentText != null && string.IsNullOrWhiteSpace(commentText)) return StudentCommentErrors.EmptyCommentText;
        if (studentId != null) StudentId = studentId.Value;
        if (teacherId != null) TeacherId = teacherId.Value;
        if (commentText != null) CommentText = commentText;
        if (type != null) Type = type;
        return Result.Success();
    }
}