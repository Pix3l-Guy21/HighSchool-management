using HighSchool.Application.Common.Interfaces;
using HighSchool.Application.Features.Users.Create;
using HighSchool.Application.Tests.Features.TestSupport;
using Moq;

namespace HighSchool.Application.Tests.Features.Users.Create;

public sealed class CreateUserHandlerTests
{
    [Fact]
    public async Task Handle_WithValidCommand_CreatesAndCommits()
    {
        var unitOfWork = CreateHandlerTestSupport.UnitOfWork();
        var handler = new CreateUserHandler(new Mock<IUserRepository>().Object, unitOfWork.Object);
        var result = await handler.Handle(
            new CreateUserCommand("jdoe", "hash", "Teacher", "jdoe@example.com", DateTime.UtcNow, DateTime.UtcNow),
            CancellationToken.None);

        CreateHandlerTestSupport.AssertSuccess(result, unitOfWork);
    }

    [Fact]
    public async Task Handle_WithEmptyUsername_ReturnsValidationError()
    {
        var unitOfWork = CreateHandlerTestSupport.UnitOfWork();
        var handler = new CreateUserHandler(new Mock<IUserRepository>().Object, unitOfWork.Object);
        var result = await handler.Handle(
            new CreateUserCommand("", "hash", "Teacher", "jdoe@example.com", DateTime.UtcNow, DateTime.UtcNow),
            CancellationToken.None);

        CreateHandlerTestSupport.AssertInvalid(result, "User.EmptyUsername", unitOfWork);
    }
}
