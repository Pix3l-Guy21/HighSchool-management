using HighSchool.Application.Common.Interfaces;
using HighSchool.Application.Features.Courses.Create;
using HighSchool.Application.Tests.Features.TestSupport;
using Moq;

namespace HighSchool.Application.Tests.Features.Courses.Create;

public sealed class CreateCourseHandlerTests
{
    [Fact]
    public async Task Handle_WithValidCommand_CreatesAndCommits()
    {
        var unitOfWork = CreateHandlerTestSupport.UnitOfWork();
        var handler = new CreateCourseHandler(new Mock<ICourseRepository>().Object, unitOfWork.Object);
        var result = await handler.Handle(
            new CreateCourseCommand("Mathematics", "MATH101", Guid.NewGuid(), "Core course"),
            CancellationToken.None);

        CreateHandlerTestSupport.AssertSuccess(result, unitOfWork);
    }

    [Fact]
    public async Task Handle_WithEmptyName_ReturnsValidationError()
    {
        var unitOfWork = CreateHandlerTestSupport.UnitOfWork();
        var handler = new CreateCourseHandler(new Mock<ICourseRepository>().Object, unitOfWork.Object);
        var result = await handler.Handle(
            new CreateCourseCommand("", "MATH101", Guid.NewGuid(), "Core course"),
            CancellationToken.None);

        CreateHandlerTestSupport.AssertInvalid(result, "Course.EmptyName", unitOfWork);
    }
}
