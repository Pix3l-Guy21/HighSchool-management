using HighSchool.Application.Common.Interfaces;

namespace HighSchool.Application.Features.StudentComments.Create;

public sealed record CreateStudentCommentCommand(
    Guid StudentId,
    Guid TeacherId,
    string CommentText,
    string Type,
    DateTime CreatedAt
) : ICommand<Guid>;