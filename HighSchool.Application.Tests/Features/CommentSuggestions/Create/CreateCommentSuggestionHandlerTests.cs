using HighSchool.Application.Common.Interfaces;
using HighSchool.Application.Features.CommentSuggestions.Create;
using HighSchool.Application.Tests.Features.TestSupport;
using Moq;

namespace HighSchool.Application.Tests.Features.CommentSuggestions.Create;

public sealed class CreateCommentSuggestionHandlerTests
{
    [Fact]
    public async Task Handle_WithValidCommand_CreatesAndCommits()
    {
        var unitOfWork = CreateHandlerTestSupport.UnitOfWork();
        var handler = new CreateCommentSuggestionHandler(new Mock<ICommentSuggestionRepository>().Object, unitOfWork.Object);
        var result = await handler.Handle(new CreateCommentSuggestionCommand("Praise", "Good work", "Positive"), CancellationToken.None);

        CreateHandlerTestSupport.AssertSuccess(result, unitOfWork);
    }

    [Fact]
    public async Task Handle_WithEmptyCategory_ReturnsValidationError()
    {
        var unitOfWork = CreateHandlerTestSupport.UnitOfWork();
        var handler = new CreateCommentSuggestionHandler(new Mock<ICommentSuggestionRepository>().Object, unitOfWork.Object);
        var result = await handler.Handle(new CreateCommentSuggestionCommand("", "Good work", "Positive"), CancellationToken.None);

        CreateHandlerTestSupport.AssertInvalid(result, "CommentSuggestion.EmptyCategory", unitOfWork);
    }
}
