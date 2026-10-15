using HighSchool.Application.Common.Interfaces;
using HighSchool.Application.Features.Departments.Create;
using HighSchool.Application.Tests.Features.TestSupport;
using Moq;

namespace HighSchool.Application.Tests.Features.Departments.Create;

public sealed class CreateDepartmentHandlerTests
{
    [Fact]
    public async Task Handle_WithValidCommand_CreatesAndCommits()
    {
        var unitOfWork = CreateHandlerTestSupport.UnitOfWork();
        var handler = new CreateDepartmentHandler(new Mock<IDepartmentRepository>().Object, unitOfWork.Object);
        var result = await handler.Handle(new CreateDepartmentCommand("Science", "Science department"), CancellationToken.None);

        CreateHandlerTestSupport.AssertSuccess(result, unitOfWork);
    }

    [Fact]
    public async Task Handle_WithEmptyName_ReturnsValidationError()
    {
        var unitOfWork = CreateHandlerTestSupport.UnitOfWork();
        var handler = new CreateDepartmentHandler(new Mock<IDepartmentRepository>().Object, unitOfWork.Object);
        var result = await handler.Handle(new CreateDepartmentCommand("", "Science department"), CancellationToken.None);

        CreateHandlerTestSupport.AssertInvalid(result, "Department.EmptyName", unitOfWork);
    }
}
