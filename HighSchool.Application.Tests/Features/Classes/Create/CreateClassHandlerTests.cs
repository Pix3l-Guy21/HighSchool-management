using HighSchool.Application.Common.Interfaces;
using HighSchool.Application.Features.Classes.Create;
using HighSchool.Application.Tests.Features.TestSupport;
using Moq;

namespace HighSchool.Application.Tests.Features.Classes.Create;

public sealed class CreateClassHandlerTests
{
    [Fact]
    public async Task Handle_WithValidCommand_CreatesAndCommits()
    {
        var unitOfWork = CreateHandlerTestSupport.UnitOfWork();
        var handler = new CreateClassHandler(new Mock<IClassRepository>().Object, unitOfWork.Object);
        var result = await handler.Handle(
            new CreateClassCommand("Class A", "2026-2027", Guid.NewGuid()),
            CancellationToken.None);

        CreateHandlerTestSupport.AssertSuccess(result, unitOfWork);
    }

    [Fact]
    public async Task Handle_WithEmptyName_ReturnsValidationError()
    {
        var unitOfWork = CreateHandlerTestSupport.UnitOfWork();
        var handler = new CreateClassHandler(new Mock<IClassRepository>().Object, unitOfWork.Object);
        var result = await handler.Handle(
            new CreateClassCommand("", "2026-2027", Guid.NewGuid()),
            CancellationToken.None);

        CreateHandlerTestSupport.AssertInvalid(result, "Class.EmptyName", unitOfWork);
    }
}
