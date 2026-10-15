using HighSchool.Application.Common.Interfaces;
using HighSchool.Application.Features.TeacherAttendances.Create;
using HighSchool.Application.Tests.Features.TestSupport;
using Moq;

namespace HighSchool.Application.Tests.Features.TeacherAttendances.Create;

public sealed class CreateTeacherAttendanceHandlerTests
{
    [Fact]
    public async Task Handle_WithValidCommand_CreatesAndCommits()
    {
        var unitOfWork = CreateHandlerTestSupport.UnitOfWork();
        var handler = new CreateTeacherAttendanceHandler(new Mock<ITeacherAttendanceRepository>().Object, unitOfWork.Object);
        var result = await handler.Handle(
            new CreateTeacherAttendanceCommand(Guid.NewGuid(), new DateOnly(2026, 10, 1), "Present", new TimeOnly(8, 0), new TimeOnly(16, 0)),
            CancellationToken.None);

        CreateHandlerTestSupport.AssertSuccess(result, unitOfWork);
    }

    [Fact]
    public async Task Handle_WithEmptyTeacherId_ReturnsValidationError()
    {
        var unitOfWork = CreateHandlerTestSupport.UnitOfWork();
        var handler = new CreateTeacherAttendanceHandler(new Mock<ITeacherAttendanceRepository>().Object, unitOfWork.Object);
        var result = await handler.Handle(
            new CreateTeacherAttendanceCommand(Guid.Empty, new DateOnly(2026, 10, 1), "Present", new TimeOnly(8, 0), new TimeOnly(16, 0)),
            CancellationToken.None);

        CreateHandlerTestSupport.AssertInvalid(result, "TeacherAttendance.EmptyTeacherId", unitOfWork);
    }
}
