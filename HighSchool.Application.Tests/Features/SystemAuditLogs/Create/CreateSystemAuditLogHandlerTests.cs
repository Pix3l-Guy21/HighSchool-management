using HighSchool.Application.Common.Interfaces;
using HighSchool.Application.Features.SystemAuditLogs.Create;
using HighSchool.Application.Tests.Features.TestSupport;
using Moq;

namespace HighSchool.Application.Tests.Features.SystemAuditLogs.Create;

public sealed class CreateSystemAuditLogHandlerTests
{
    [Fact]
    public async Task Handle_WithValidCommand_CreatesAndCommits()
    {
        var unitOfWork = CreateHandlerTestSupport.UnitOfWork();
        var handler = new CreateSystemAuditLogHandler(new Mock<ISystemAuditLogRepository>().Object, unitOfWork.Object);
        var result = await handler.Handle(
            new CreateSystemAuditLogCommand(Guid.NewGuid(), "Created", "Assessment created", DateTime.UtcNow),
            CancellationToken.None);

        CreateHandlerTestSupport.AssertSuccess(result, unitOfWork);
    }

    [Fact]
    public async Task Handle_WithEmptyUserId_ReturnsValidationError()
    {
        var unitOfWork = CreateHandlerTestSupport.UnitOfWork();
        var handler = new CreateSystemAuditLogHandler(new Mock<ISystemAuditLogRepository>().Object, unitOfWork.Object);
        var result = await handler.Handle(
            new CreateSystemAuditLogCommand(Guid.Empty, "Created", "Assessment created", DateTime.UtcNow),
            CancellationToken.None);

        CreateHandlerTestSupport.AssertInvalid(result, "SystemAuditLog.EmptyUserId", unitOfWork);
    }
}
