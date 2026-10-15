using HighSchool.Application.Common.Interfaces;
using HighSchool.Application.Features.StudentComments.Create;
using HighSchool.Application.Tests.Features.TestSupport;
using Moq;

namespace HighSchool.Application.Tests.Features.StudentComments.Create;

public sealed class CreateStudentCommentHandlerTests
{
    [Fact]
    public async Task Handle_WithValidCommand_CreatesAndCommits()
    {
        var unitOfWork = CreateHandlerTestSupport.UnitOfWork();
        var handler = new CreateStudentCommentHandler(new Mock<IStudentCommentRepository>().Object, unitOfWork.Object);
        var result = await handler.Handle(
            new CreateStudentCommentCommand(Guid.NewGuid(), Guid.NewGuid(), "Great progress", "Praise", DateTime.UtcNow),
            CancellationToken.None);

        CreateHandlerTestSupport.AssertSuccess(result, unitOfWork);
    }

    [Fact]
    public async Task Handle_WithEmptyStudentId_ReturnsValidationError()
    {
        var unitOfWork = CreateHandlerTestSupport.UnitOfWork();
        var handler = new CreateStudentCommentHandler(new Mock<IStudentCommentRepository>().Object, unitOfWork.Object);
        var result = await handler.Handle(
            new CreateStudentCommentCommand(Guid.Empty, Guid.NewGuid(), "Great progress", "Praise", DateTime.UtcNow),
            CancellationToken.None);

        CreateHandlerTestSupport.AssertInvalid(result, "StudentComment.EmptyStudentId", unitOfWork);
    }
}
