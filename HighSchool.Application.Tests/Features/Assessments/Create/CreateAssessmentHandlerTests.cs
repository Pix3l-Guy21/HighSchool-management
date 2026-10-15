using HighSchool.Application.Common.Interfaces;
using HighSchool.Application.Features.Assessments.Create;
using HighSchool.Domain.Entities;
using Moq;

namespace HighSchool.Application.Tests.Features.Assessments.Create;

public sealed class CreateAssessmentHandlerTests
{
    [Fact]
    public async Task Handle_WithValidCommand_CreatesAssessmentAndCommits()
    {
        var repository = new Mock<IAssessmentRepository>();
        var unitOfWork = new Mock<IUnitOfWork>();
        var handler = new CreateAssessmentHandler(
            repository.Object,
            unitOfWork.Object);
        var command = new CreateAssessmentCommand(
            Guid.NewGuid(),
            Guid.NewGuid(),
            "Midterm Exam",
            "Exam",
            25,
            new DateOnly(2026, 10, 20));

        var result = await handler.Handle(command, CancellationToken.None);

        Assert.True(result.IsSuccess);
        Assert.NotEqual(Guid.Empty, result.Value);
        repository.Verify(
            x => x.AddAsync(
                It.Is<Assessment>(assessment =>
                    assessment.CourseId == command.CourseId &&
                    assessment.TeacherId == command.TeacherId &&
                    assessment.Title == command.Title &&
                    assessment.Type == command.Type &&
                    assessment.Weight == command.Weight &&
                    assessment.Date == command.Date),
                It.IsAny<CancellationToken>()),
            Times.Once);
        unitOfWork.Verify(
            x => x.SaveChangesAsync(It.IsAny<CancellationToken>()),
            Times.Once);
    }

    public static IEnumerable<object?[]> InvalidCommands()
    {
        yield return
        [
            Guid.Empty,
            Guid.NewGuid(),
            "Midterm Exam",
            "Exam",
            25f,
            new DateOnly(2026, 10, 20),
            "Assessment.EmptyCourseId"
        ];
        yield return
        [
            Guid.NewGuid(),
            Guid.Empty,
            "Midterm Exam",
            "Exam",
            25f,
            new DateOnly(2026, 10, 20),
            "Assessment.EmptyTeacherId"
        ];
        yield return
        [
            Guid.NewGuid(),
            Guid.NewGuid(),
            "",
            "Exam",
            25f,
            new DateOnly(2026, 10, 20),
            "Assessment.EmptyTitle"
        ];
        yield return
        [
            Guid.NewGuid(),
            Guid.NewGuid(),
            "Midterm Exam",
            "Exam",
            25f,
            null,
            "Assessment.NullDate"
        ];
    }

    [Theory]
    [MemberData(nameof(InvalidCommands))]
    public async Task Handle_WithInvalidCommand_ReturnsErrorAndDoesNotPersist(
        Guid courseId,
        Guid teacherId,
        string title,
        string? type,
        float? weight,
        DateOnly? date,
        string expectedErrorCode)
    {
        var repository = new Mock<IAssessmentRepository>();
        var unitOfWork = new Mock<IUnitOfWork>();
        var handler = new CreateAssessmentHandler(
            repository.Object,
            unitOfWork.Object);
        var command = new CreateAssessmentCommand(
            courseId,
            teacherId,
            title,
            type,
            weight,
            date);

        var result = await handler.Handle(command, CancellationToken.None);

        Assert.False(result.IsSuccess);
        Assert.NotNull(result.Error);
        Assert.Equal(expectedErrorCode, result.Error.Code);
        repository.Verify(
            x => x.AddAsync(
                It.IsAny<Assessment>(),
                It.IsAny<CancellationToken>()),
            Times.Never);
        unitOfWork.Verify(
            x => x.SaveChangesAsync(It.IsAny<CancellationToken>()),
            Times.Never);
    }
}
