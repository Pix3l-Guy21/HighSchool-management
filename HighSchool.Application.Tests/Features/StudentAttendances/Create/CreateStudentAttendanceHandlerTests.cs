using HighSchool.Application.Common.Interfaces;
using HighSchool.Application.Features.StudentAttendances.Create;
using HighSchool.Application.Tests.Features.TestSupport;
using Moq;

namespace HighSchool.Application.Tests.Features.StudentAttendances.Create;

public sealed class CreateStudentAttendanceHandlerTests
{
    [Fact]
    public async Task Handle_WithValidCommand_CreatesAndCommits()
    {
        var unitOfWork = CreateHandlerTestSupport.UnitOfWork();
        var handler = new CreateStudentAttendanceHandler(new Mock<IStudentAttendanceRepository>().Object, unitOfWork.Object);
        var result = await handler.Handle(
            new CreateStudentAttendanceCommand(Guid.NewGuid(), Guid.NewGuid(), new DateOnly(2026, 10, 1), "Present", Guid.NewGuid(), "On time"),
            CancellationToken.None);

        CreateHandlerTestSupport.AssertSuccess(result, unitOfWork);
    }

    [Fact]
    public async Task Handle_WithEmptyStudentId_ReturnsValidationError()
    {
        var unitOfWork = CreateHandlerTestSupport.UnitOfWork();
        var handler = new CreateStudentAttendanceHandler(new Mock<IStudentAttendanceRepository>().Object, unitOfWork.Object);
        var result = await handler.Handle(
            new CreateStudentAttendanceCommand(Guid.Empty, Guid.NewGuid(), new DateOnly(2026, 10, 1), "Present", Guid.NewGuid(), "On time"),
            CancellationToken.None);

        CreateHandlerTestSupport.AssertInvalid(result, "StudentAttendance.EmptyStudentId", unitOfWork);
    }
}
