using HighSchool.Application.Common.Interfaces;
using HighSchool.Application.Features.StudentGrades.Create;
using HighSchool.Application.Tests.Features.TestSupport;
using Moq;

namespace HighSchool.Application.Tests.Features.StudentGrades.Create;

public sealed class CreateStudentGradeHandlerTests
{
    [Fact]
    public async Task Handle_WithValidCommand_CreatesAndCommits()
    {
        var unitOfWork = CreateHandlerTestSupport.UnitOfWork();
        var handler = new CreateStudentGradeHandler(new Mock<IStudentGradeRepository>().Object, unitOfWork.Object);
        var result = await handler.Handle(
            new CreateStudentGradeCommand(Guid.NewGuid(), Guid.NewGuid(), Guid.NewGuid(), Guid.NewGuid(), "Exam", "Good", 90, new DateOnly(2026, 10, 1)),
            CancellationToken.None);

        CreateHandlerTestSupport.AssertSuccess(result, unitOfWork);
    }

    [Fact]
    public async Task Handle_WithEmptyStudentId_ReturnsValidationError()
    {
        var unitOfWork = CreateHandlerTestSupport.UnitOfWork();
        var handler = new CreateStudentGradeHandler(new Mock<IStudentGradeRepository>().Object, unitOfWork.Object);
        var result = await handler.Handle(
            new CreateStudentGradeCommand(Guid.Empty, Guid.NewGuid(), Guid.NewGuid(), Guid.NewGuid(), "Exam", "Good", 90, new DateOnly(2026, 10, 1)),
            CancellationToken.None);

        CreateHandlerTestSupport.AssertInvalid(result, "StudentGrade.EmptyStudentId", unitOfWork);
    }
}
