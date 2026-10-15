using HighSchool.Application.Common.Interfaces;
using HighSchool.Domain.Common;
using HighSchool.Domain.Entities;

namespace HighSchool.Application.Features.StudentComments.Create;

public sealed class CreateStudentCommentHandler : ICommandHandler<CreateStudentCommentCommand, Guid>
{
    private readonly IStudentCommentRepository _studentCommentRepository;
    private readonly IUnitOfWork _unitOfWork;

    public CreateStudentCommentHandler(
        IStudentCommentRepository studentCommentRepository,
        IUnitOfWork unitOfWork)
    {
        _studentCommentRepository = studentCommentRepository;
        _unitOfWork = unitOfWork;
    }
    public async Task<Result<Guid>> Handle(
        CreateStudentCommentCommand command,
        CancellationToken cancellationToken)
    {
        var studentCommentResult = StudentComment.Create(
            Guid.NewGuid(),
            command.StudentId,
            command.TeacherId,
            command.CommentText,
            command.Type
        );
        if (!studentCommentResult.IsSuccess) return studentCommentResult.Error!;

        var studentComment = studentCommentResult.Value;

        await _studentCommentRepository.AddAsync(studentComment, cancellationToken);
        await _unitOfWork.SaveChangesAsync(cancellationToken);
        return studentComment.Id;
    }
}