using HighSchool.Application.Common.Interfaces;
using HighSchool.Application.Features.ClassSchedules.Create;
using HighSchool.Application.Tests.Features.TestSupport;
using Moq;

namespace HighSchool.Application.Tests.Features.ClassSchedules.Create;

public sealed class CreateClassScheduleHandlerTests
{
    [Fact]
    public async Task Handle_WithValidCommand_CreatesAndCommits()
    {
        var unitOfWork = CreateHandlerTestSupport.UnitOfWork();
        var handler = new CreateClassScheduleHandler(new Mock<IClassScheduleRepository>().Object, unitOfWork.Object);
        var result = await handler.Handle(
            new CreateClassScheduleCommand(Guid.NewGuid(), Guid.NewGuid(), Guid.NewGuid(), DayOfWeek.Monday, new TimeOnly(8, 0), new TimeOnly(9, 0), "Room 1"),
            CancellationToken.None);

        CreateHandlerTestSupport.AssertSuccess(result, unitOfWork);
    }

    [Fact]
    public async Task Handle_WithEmptyClassId_ReturnsValidationError()
    {
        var unitOfWork = CreateHandlerTestSupport.UnitOfWork();
        var handler = new CreateClassScheduleHandler(new Mock<IClassScheduleRepository>().Object, unitOfWork.Object);
        var result = await handler.Handle(
            new CreateClassScheduleCommand(Guid.Empty, Guid.NewGuid(), Guid.NewGuid(), DayOfWeek.Monday, new TimeOnly(8, 0), new TimeOnly(9, 0), "Room 1"),
            CancellationToken.None);

        CreateHandlerTestSupport.AssertInvalid(result, "ClassSchedule.EmptyClassId", unitOfWork);
    }
}
