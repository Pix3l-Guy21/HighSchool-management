using HighSchool.Domain.Common;
using HighSchool.Domain.Errors;

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
        if (id == Guid.Empty) return StudentGradeErrors.EmptyId;
        if (courseId == Guid.Empty) return StudentGradeErrors.EmptyCourseId;
        if (studentId == Guid.Empty) return StudentGradeErrors.EmptyStudentId;
        if (assignmentId == Guid.Empty) return StudentGradeErrors.EmptyAssignmentId;
        if (assessmentId == Guid.Empty) return StudentGradeErrors.EmptyAssessmentId;
        if (string.IsNullOrWhiteSpace(title)) return StudentGradeErrors.EmptyTitle;
        return gradedDate == null
            ? StudentGradeErrors.EmptyGradedDate
            : new StudentGrade(id, courseId, studentId, assignmentId, assessmentId, title, feedback, score, gradedDate.Value);
    }

    public Result Update(Guid? courseId, Guid? studentId, Guid? assignmentId, Guid? assessmentId, string? title, string? feedback, float? score, DateOnly? gradedDate)
    {
        if (courseId == Guid.Empty) return StudentGradeErrors.EmptyCourseId;
        if (studentId == Guid.Empty) return StudentGradeErrors.EmptyStudentId;
        if (assignmentId == Guid.Empty) return StudentGradeErrors.EmptyAssignmentId;
        if (assessmentId == Guid.Empty) return StudentGradeErrors.EmptyAssessmentId;
        if (title != null && string.IsNullOrWhiteSpace(title)) return StudentGradeErrors.EmptyTitle;
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