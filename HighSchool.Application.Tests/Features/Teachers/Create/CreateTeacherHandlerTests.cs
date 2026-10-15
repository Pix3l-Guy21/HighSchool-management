using HighSchool.Application.Common.Interfaces;
using HighSchool.Application.Features.Teachers.Create;
using HighSchool.Application.Tests.Features.TestSupport;
using Moq;

namespace HighSchool.Application.Tests.Features.Teachers.Create;

public sealed class CreateTeacherHandlerTests
{
    [Fact]
    public async Task Handle_WithValidCommand_CreatesAndCommits()
    {
        var unitOfWork = CreateHandlerTestSupport.UnitOfWork();
        var handler = new CreateTeacherHandler(new Mock<ITeacherRepository>().Object, unitOfWork.Object);
        var result = await handler.Handle(
            new CreateTeacherCommand(Guid.NewGuid(), Guid.NewGuid(), new DateTime(2026, 9, 1)),
            CancellationToken.None);

        CreateHandlerTestSupport.AssertSuccess(result, unitOfWork);
    }

    [Fact]
    public async Task Handle_WithEmptyUserId_ReturnsValidationError()
    {
        var unitOfWork = CreateHandlerTestSupport.UnitOfWork();
        var handler = new CreateTeacherHandler(new Mock<ITeacherRepository>().Object, unitOfWork.Object);
        var result = await handler.Handle(
            new CreateTeacherCommand(Guid.Empty, Guid.NewGuid(), new DateTime(2026, 9, 1)),
            CancellationToken.None);

        CreateHandlerTestSupport.AssertInvalid(result, "Teacher.EmptyUserId", unitOfWork);
    }
}
