using HighSchool.Application.Common.Interfaces;
using HighSchool.Domain.Entities;
using Moq;

namespace HighSchool.Application.Tests.Features.TestSupport;

internal static class CreateHandlerTestSupport
{
    public static Mock<IUnitOfWork> UnitOfWork()
    {
        var unitOfWork = new Mock<IUnitOfWork>();
        unitOfWork
            .Setup(x => x.SaveChangesAsync(It.IsAny<CancellationToken>()))
            .ReturnsAsync(1);
        return unitOfWork;
    }

    public static void AssertSuccess(
        HighSchool.Domain.Common.Result<Guid> result,
        Mock<IUnitOfWork> unitOfWork)
    {
        Assert.True(result.IsSuccess);
        Assert.NotEqual(Guid.Empty, result.Value);
        unitOfWork.Verify(
            x => x.SaveChangesAsync(It.IsAny<CancellationToken>()),
            Times.Once);
    }

    public static void AssertInvalid(
        HighSchool.Domain.Common.Result<Guid> result,
        string errorCode,
        Mock<IUnitOfWork> unitOfWork)
    {
        Assert.False(result.IsSuccess);
        Assert.Equal(errorCode, result.Error?.Code);
        unitOfWork.Verify(
            x => x.SaveChangesAsync(It.IsAny<CancellationToken>()),
            Times.Never);
    }
}
