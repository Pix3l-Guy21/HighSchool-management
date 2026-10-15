using HighSchool.Application.Common.Interfaces;
using HighSchool.Application.Features.Assignments.Create;
using HighSchool.Application.Tests.Features.TestSupport;
using Moq;

namespace HighSchool.Application.Tests.Features.Assignments.Create;

public sealed class CreateAssignmentHandlerTests
{
    [Fact]
    public async Task Handle_WithValidCommand_CreatesAndCommits()
    {
        var unitOfWork = CreateHandlerTestSupport.UnitOfWork();
        var handler = new CreateAssignmentHandler(new Mock<IAssignmentRepository>().Object, unitOfWork.Object);
        var result = await handler.Handle(
            new CreateAssignmentCommand(Guid.NewGuid(), Guid.NewGuid(), "Homework", "Description", 100, new DateOnly(2026, 11, 1)),
            CancellationToken.None);

        CreateHandlerTestSupport.AssertSuccess(result, unitOfWork);
    }

    [Fact]
    public async Task Handle_WithEmptyCourseId_ReturnsValidationError()
    {
        var unitOfWork = CreateHandlerTestSupport.UnitOfWork();
        var handler = new CreateAssignmentHandler(new Mock<IAssignmentRepository>().Object, unitOfWork.Object);
        var result = await handler.Handle(
            new CreateAssignmentCommand(Guid.Empty, Guid.NewGuid(), "Homework", "Description", 100, new DateOnly(2026, 11, 1)),
            CancellationToken.None);

        CreateHandlerTestSupport.AssertInvalid(result, "Assignment.EmptyCourseId", unitOfWork);
    }
}
