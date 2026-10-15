using HighSchool.Application.Common.Interfaces;
using HighSchool.Application.Features.Profiles.Create;
using HighSchool.Application.Tests.Features.TestSupport;
using Moq;

namespace HighSchool.Application.Tests.Features.Profiles.Create;

public sealed class CreateProfileHandlerTests
{
    [Fact]
    public async Task Handle_WithValidCommand_CreatesAndCommits()
    {
        var unitOfWork = CreateHandlerTestSupport.UnitOfWork();
        var handler = new CreateProfileHandler(new Mock<IProfileRepository>().Object, unitOfWork.Object);
        var result = await handler.Handle(
            new CreateProfileCommand(Guid.NewGuid(), "Jane", "Doe", "555-0100", "Address", new DateOnly(2000, 1, 1)),
            CancellationToken.None);

        CreateHandlerTestSupport.AssertSuccess(result, unitOfWork);
    }

    [Fact]
    public async Task Handle_WithEmptyUserId_ReturnsValidationError()
    {
        var unitOfWork = CreateHandlerTestSupport.UnitOfWork();
        var handler = new CreateProfileHandler(new Mock<IProfileRepository>().Object, unitOfWork.Object);
        var result = await handler.Handle(
            new CreateProfileCommand(Guid.Empty, "Jane", "Doe", "555-0100", "Address", new DateOnly(2000, 1, 1)),
            CancellationToken.None);

        CreateHandlerTestSupport.AssertInvalid(result, "Profile.EmptyUserId", unitOfWork);
    }
}
