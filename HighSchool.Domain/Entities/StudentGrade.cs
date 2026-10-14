using HighSchool.Domain.Common;

namespace HighSchool.Domain.Entities;

public class StudentGrade
{
    public Guid Id { get; private set; }
    public Guid StudentId { get; private set; }
    public Guid CourseId { get; private set; }
    public Guid AssignmentId { get; private set; }
    public Guid AssessmentId { get; private set; }
    public string Title { get; private set; } = string.Empty;   
    public string? Feedback { get; private set; }   
    public float Score { get; private set; }
    public DateOnly GradedDate { get; private set; }   

    private StudentGrade() { }

    private StudentGrade(Guid id, Guid courseId, Guid studentId, Guid assignmentId, Guid assessmentId, string title, string? feedback, float? score, DateOnly gradedDate)
    {
        Id = id;
        CourseId = courseId;
        StudentId = studentId;
        AssignmentId = assignmentId;
        AssessmentId = assessmentId;
        Title = title;
        Feedback = feedback ?? "No feedback";
        Score = score ?? 0;
        GradedDate = gradedDate;
    }

    public static Result<StudentGrade> Create(Guid id, Guid courseId, Guid studentId, Guid assignmentId, Guid assessmentId, string title, string? feedback, float? score, DateOnly? gradedDate)
    {
        if (id == Guid.Empty) return new Error("StudentGrade.EmptyId", "StudentGrade Id cannot be empty.", ErrorType.Conflict);
        if (courseId == Guid.Empty) return new Error("StudentGrade.EmptyCourseId", "Course Id cannot be empty.", ErrorType.Conflict);
        if (studentId == Guid.Empty) return new Error("StudentGrade.EmptyStudentId", "Student Id cannot be empty.", ErrorType.Conflict);
        if (assignmentId == Guid.Empty) return new Error("StudentGrade.EmptyAssignmentId", "Assignment Id cannot be empty.", ErrorType.Conflict);
        if (assessmentId == Guid.Empty) return new Error("StudentGrade.EmptyAssessmentId", "Assessment Id cannot be empty.", ErrorType.Conflict);
        if (string.IsNullOrWhiteSpace(title)) return new Error("StudentGrade.EmptyTitle", "StudentGrade Title cannot be empty.", ErrorType.Conflict);
        return gradedDate == null
            ? new Error("StudentGrade.EmptyGradedDate", "StudentGrade graded date cannot be empty.", ErrorType.Conflict)
            : new StudentGrade(id, courseId, studentId, assignmentId, assessmentId, title, feedback, score, gradedDate.Value);
    }

    public Result Update(Guid? courseId, Guid? studentId, Guid? assignmentId, Guid? assessmentId, string? title, string? feedback, float? score, DateOnly? gradedDate)
    {
        if (courseId == Guid.Empty) return new Error("StudentGrade.EmptyCourseId", "Course Id cannot be empty.", ErrorType.Conflict);
        if (studentId == Guid.Empty) return new Error("StudentGrade.EmptyStudentId", "Student Id cannot be empty.", ErrorType.Conflict);
        if (assignmentId == Guid.Empty) return new Error("StudentGrade.EmptyAssignmentId", "Assignment Id cannot be empty.", ErrorType.Conflict);
        if (assessmentId == Guid.Empty) return new Error("StudentGrade.EmptyAssessmentId", "Assessment Id cannot be empty.", ErrorType.Conflict);
        if (title != null && string.IsNullOrWhiteSpace(title)) return new Error("StudentGrade.EmptyTitle", "StudentGrade Title cannot be empty.", ErrorType.Conflict);
        if (courseId != null) CourseId = courseId.Value;
        if (studentId != null) StudentId = studentId.Value;
        if (assignmentId != null) AssignmentId = assignmentId.Value;
        if (assessmentId != null) AssessmentId = assessmentId.Value;
        if (title != null) Title = title;
        if (feedback != null) Feedback = feedback;
        if (score != null) Score = score.Value;
        if (gradedDate != null) GradedDate = gradedDate.Value;
        return Result.Success();
    }
}