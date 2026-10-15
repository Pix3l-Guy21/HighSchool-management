using HighSchool.Application.Common.Interfaces;
using HighSchool.Application.Features.Students.Create;
using HighSchool.Application.Tests.Features.TestSupport;
using Moq;

namespace HighSchool.Application.Tests.Features.Students.Create;

public sealed class CreateStudentHandlerTests
{
    [Fact]
    public async Task Handle_WithValidCommand_CreatesAndCommits()
    {
        var unitOfWork = CreateHandlerTestSupport.UnitOfWork();
        var handler = new CreateStudentHandler(new Mock<IStudentRepository>().Object, unitOfWork.Object);
        var result = await handler.Handle(
            new CreateStudentCommand(Guid.NewGuid(), Guid.NewGuid(), new DateTime(2026, 9, 1)),
            CancellationToken.None);

        CreateHandlerTestSupport.AssertSuccess(result, unitOfWork);
    }

    [Fact]
    public async Task Handle_WithEmptyUserId_ReturnsValidationError()
    {
        var unitOfWork = CreateHandlerTestSupport.UnitOfWork();
        var handler = new CreateStudentHandler(new Mock<IStudentRepository>().Object, unitOfWork.Object);
        var result = await handler.Handle(
            new CreateStudentCommand(Guid.Empty, Guid.NewGuid(), new DateTime(2026, 9, 1)),
            CancellationToken.None);

        CreateHandlerTestSupport.AssertInvalid(result, "Student.EmptyUserId", unitOfWork);
    }
}
