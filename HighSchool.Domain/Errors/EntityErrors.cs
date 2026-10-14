using HighSchool.Domain.Common;

namespace HighSchool.Domain.Errors;

public static class AssessmentErrors
{
    public static Error EmptyId => new("Assessment.EmptyId", "Assessment Id cannot be empty.", ErrorType.Conflict);
    public static Error EmptyCourseId => new("Assessment.EmptyCourseId", "Course Id cannot be empty.", ErrorType.Conflict);
    public static Error EmptyTeacherId => new("Assessment.EmptyTeacherId", "Teacher Id cannot be empty.", ErrorType.Conflict);
    public static Error EmptyTitle => new("Assessment.EmptyTitle", "Assessment Title cannot be empty.", ErrorType.Conflict);
    public static Error NullDate => new("Assessment.NullDate", "Assessment date cannot be empty.", ErrorType.Conflict);
    public static Error NotFound(Guid assessmentId) => new("Assessment.NotFound", $"Assessment with ID {assessmentId} was not found.", ErrorType.NotFound);
}

public static class AssignmentErrors
{
    public static Error EmptyId => new("Assignment.EmptyId", "Assignment Id cannot be empty.", ErrorType.Conflict);
    public static Error EmptyCourseId => new("Assignment.EmptyCourseId", "Assignment Course Id cannot be empty.", ErrorType.Conflict);
    public static Error EmptyTeacherId => new("Assignment.EmptyTeacherId", "Assignment Teacher Id cannot be empty.", ErrorType.Conflict);
    public static Error EmptyTitle => new("Assignment.EmptyTitle", "Assignment Title cannot be empty.", ErrorType.Conflict);
    public static Error EmptyDueDate => new("Assignment.EmptyDueDate", "Assignment due date cannot be empty.", ErrorType.Conflict);
    public static Error NotFound(Guid assignmentId) => new("Assignment.NotFound", $"Assignment with ID {assignmentId} was not found.", ErrorType.NotFound);
}

public static class ClassErrors
{
    public static Error EmptyId => new("Class.EmptyId", "Class Id cannot be empty.", ErrorType.Conflict);
    public static Error EmptyName => new("Class.EmptyName", "Class name cannot be empty.", ErrorType.Conflict);
    public static Error EmptyAcademicYear => new("Class.EmptyAcademicYear", "Class academic year cannot be empty.", ErrorType.Conflict);
    public static Error EmptyHomeRoomTeacherId => new("Class.EmptyHomeRoomTeacherId", "Class home room teacher id cannot be empty.", ErrorType.Conflict);
}

public static class ClassScheduleErrors
{
    public static Error EmptyId => new("ClassSchedule.EmptyId", "ClassSchedule Id cannot be empty.", ErrorType.Conflict);
    public static Error EmptyClassId => new("ClassSchedule.EmptyClassId", "Class Id cannot be empty.", ErrorType.Conflict);
    public static Error EmptyCourseId => new("ClassSchedule.EmptyCourseId", "Course Id cannot be empty.", ErrorType.Conflict);
    public static Error EmptyTeacherId => new("ClassSchedule.EmptyTeacherId", "Teacher Id cannot be empty.", ErrorType.Conflict);
    public static Error EmptyRoom => new("ClassSchedule.EmptyRoom", "Room cannot be empty.", ErrorType.Conflict);
    public static Error InvalidTimeRange => new("ClassSchedule.InvalidTimeRange", "End time must be after start time.", ErrorType.Conflict);
}

public static class CommentSuggestionErrors
{
    public static Error EmptyId => new("CommentSuggestion.EmptyId", "CommentSuggestion Id cannot be empty.", ErrorType.Conflict);
    public static Error EmptyCategory => new("CommentSuggestion.EmptyCategory", "Comment category cannot be empty.", ErrorType.Conflict);
    public static Error EmptyTemplateText => new("CommentSuggestion.EmptyTemplateText", "Comment template text cannot be empty.", ErrorType.Conflict);
    public static Error EmptyTone => new("CommentSuggestion.EmptyTone", "Comment tone cannot be empty.", ErrorType.Conflict);
}

public static class CourseErrors
{
    public static Error EmptyId => new("Course.EmptyId", "Course Id cannot be empty.", ErrorType.Conflict);
    public static Error EmptyName => new("Course.EmptyName", "Course Name cannot be empty.", ErrorType.Conflict);
    public static Error EmptyCode => new("Course.EmptyCode", "Course Code cannot be empty.", ErrorType.Conflict);
    public static Error EmptyDepartmentId => new("Course.EmptyDepartmentId", "Department Id cannot be empty.", ErrorType.Conflict);
}

public static class DepartmentErrors
{
    public static Error EmptyId => new("Department.EmptyId", "Department Id cannot be empty.", ErrorType.Conflict);
    public static Error EmptyName => new("Department.EmptyName", "Department Name cannot be empty.", ErrorType.Conflict);
}

public static class ProfileErrors
{
    public static Error EmptyId => new("Profile.EmptyId", "Profile Id cannot be empty.", ErrorType.Conflict);
    public static Error EmptyUserId => new("Profile.EmptyUserId", "Profile user Id cannot be empty.", ErrorType.Conflict);
    public static Error EmptyFirstName => new("Profile.EmptyFirstName", "Profile first name cannot be empty.", ErrorType.Conflict);
    public static Error EmptyLastName => new("Profile.EmptyLastName", "Profile last name cannot be empty.", ErrorType.Conflict);
    public static Error EmptyPhone => new("Profile.EmptyPhone", "Profile phone number cannot be empty.", ErrorType.Conflict);
    public static Error EmptyAddress => new("Profile.EmptyAddress", "Profile address cannot be empty.", ErrorType.Conflict);
    public static Error EmptyDateOfBirth => new("Profile.EmptyDateOfBirth", "Date of birth cannot be empty.", ErrorType.Conflict);
}

public static class StudentErrors
{
    public static Error EmptyId => new("Student.EmptyId", "Student Id cannot be empty.", ErrorType.Conflict);
    public static Error EmptyUserId => new("Student.EmptyUserId", "User Id cannot be empty.", ErrorType.Conflict);
    public static Error EmptyClassId => new("Student.EmptyClassId", "Class Id cannot be empty.", ErrorType.Conflict);
}

public static class StudentAttendanceErrors
{
    public static Error EmptyId => new("StudentAttendance.EmptyId", "Student Attendance Id cannot be empty.", ErrorType.Conflict);
    public static Error EmptyStudentId => new("StudentAttendance.EmptyStudentId", "Student Id cannot be empty.", ErrorType.Conflict);
    public static Error EmptyCourseId => new("StudentAttendance.EmptyCourseId", "Course Id cannot be empty.", ErrorType.Conflict);
    public static Error EmptyStatus => new("StudentAttendance.EmptyStatus", "Attendance Status cannot be empty.", ErrorType.Conflict);
    public static Error EmptyRecordedBy => new("StudentAttendance.EmptyRecordedBy", "Recorder's Id cannot be empty.", ErrorType.Conflict);
}

public static class StudentCommentErrors
{
    public static Error EmptyId => new("StudentComment.EmptyId", "StudentComment Id cannot be empty.", ErrorType.Conflict);
    public static Error EmptyStudentId => new("StudentComment.EmptyStudentId", "Student Id cannot be empty.", ErrorType.Conflict);
    public static Error EmptyTeacherId => new("StudentComment.EmptyTeacherId", "Teacher Id cannot be empty.", ErrorType.Conflict);
    public static Error EmptyCommentText => new("StudentComment.EmptyCommentText", "StudentComment CommentText cannot be empty.", ErrorType.Conflict);
}

public static class StudentGradeErrors
{
    public static Error EmptyId => new("StudentGrade.EmptyId", "StudentGrade Id cannot be empty.", ErrorType.Conflict);
    public static Error EmptyCourseId => new("StudentGrade.EmptyCourseId", "Course Id cannot be empty.", ErrorType.Conflict);
    public static Error EmptyStudentId => new("StudentGrade.EmptyStudentId", "Student Id cannot be empty.", ErrorType.Conflict);
    public static Error EmptyAssignmentId => new("StudentGrade.EmptyAssignmentId", "Assignment Id cannot be empty.", ErrorType.Conflict);
    public static Error EmptyAssessmentId => new("StudentGrade.EmptyAssessmentId", "Assessment Id cannot be empty.", ErrorType.Conflict);
    public static Error EmptyTitle => new("StudentGrade.EmptyTitle", "StudentGrade Title cannot be empty.", ErrorType.Conflict);
    public static Error EmptyGradedDate => new("StudentGrade.EmptyGradedDate", "StudentGrade graded date cannot be empty.", ErrorType.Conflict);
}

public static class TeacherErrors
{
    public static Error EmptyId => new("Teacher.EmptyId", "Teacher Id cannot be empty.", ErrorType.Conflict);
    public static Error EmptyUserId => new("Teacher.EmptyUserId", "User Id cannot be empty.", ErrorType.Conflict);
    public static Error EmptyDepartmentId => new("Teacher.EmptyDepartmentId", "Department Id cannot be empty.", ErrorType.Conflict);
}

public static class TeacherAttendanceErrors
{
    public static Error EmptyId => new("TeacherAttendance.EmptyId", "TeacherAttendance Id cannot be empty.", ErrorType.Conflict);
    public static Error EmptyTeacherId => new("TeacherAttendance.EmptyTeacherId", "Teacher Id cannot be empty.", ErrorType.Conflict);
    public static Error EmptyStatus => new("TeacherAttendance.EmptyStatus", "TeacherAttendance status cannot be empty.", ErrorType.Conflict);
}

public static class UserErrors
{
    public static Error EmptyId => new("User.EmptyId", "User Id cannot be empty.", ErrorType.Conflict);
    public static Error EmptyUsername => new("User.EmptyUsername", "Username cannot be empty.", ErrorType.Conflict);
    public static Error EmptyPasswordHash => new("User.EmptyPasswordHash", "User password cannot be empty.", ErrorType.Conflict);
    public static Error EmptyRole => new("User.EmptyRole", "User role cannot be empty.", ErrorType.Conflict);
    public static Error EmptyEmail => new("User.EmptyEmail", "User email cannot be empty.", ErrorType.Conflict);
}

public static class AdminCommunicationErrors
{
    public static Error EmptyId => new("AdminCommunication.EmptyId", "AdminCommunication Id cannot be empty.", ErrorType.Conflict);
    public static Error EmptySenderId => new("AdminCommunication.EmptySenderId", "Sender Id cannot be empty.", ErrorType.Conflict);
    public static Error EmptyRecipientId => new("AdminCommunication.EmptyRecipientId", "Recipient Id cannot be empty.", ErrorType.Conflict);
    public static Error EmptySubject => new("AdminCommunication.EmptySubject", "AdminCommunication Subject cannot be empty.", ErrorType.Conflict);
    public static Error EmptyMessage => new("AdminCommunication.EmptyMessage", "AdminCommunication Message cannot be empty.", ErrorType.Conflict);
}

public static class SystemAuditLogErrors
{
    public static Error EmptyId => new("SystemAuditLog.EmptyId", "SystemAuditLog Id cannot be empty.", ErrorType.Conflict);
    public static Error EmptyAction => new("SystemAuditLog.EmptyAction", "System Log action cannot be empty.", ErrorType.Conflict);
    public static Error EmptyDetails => new("SystemAuditLog.EmptyDetails", "System Log details cannot be empty.", ErrorType.Conflict);
}
