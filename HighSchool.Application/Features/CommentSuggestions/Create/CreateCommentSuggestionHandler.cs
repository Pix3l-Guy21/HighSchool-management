using HighSchool.Application.Common.Interfaces;
using HighSchool.Domain.Common;
using HighSchool.Domain.Entities;

namespace HighSchool.Application.Features.CommentSuggestions.Create;

public sealed class CreateCommentSuggestionHandler : ICommandHandler<CreateCommentSuggestionCommand, Guid>
{
  private readonly ICommentSuggestionRepository _commentSuggestionRepository;
  private readonly IUnitOfWork _unitOfWork;

  public CreateCommentSuggestionHandler(
    ICommentSuggestionRepository commentSuggestionRepository,
    IUnitOfWork unitOfWork)
  {
    _commentSuggestionRepository = commentSuggestionRepository;
    _unitOfWork = unitOfWork;
  }
  public async Task<Result<Guid>> Handle(
    CreateCommentSuggestionCommand command,
    CancellationToken cancellationToken)
  {
    var commentSuggestionResult = CommentSuggestion.Create(
      Guid.NewGuid(),
      command.Category,
      command.TemplateText,
      command.Tone
    );
    if (!commentSuggestionResult.IsSuccess) return commentSuggestionResult.Error!;

    var commentSuggestion = commentSuggestionResult.Value;

    await _commentSuggestionRepository.AddAsync(commentSuggestion, cancellationToken);
    await _unitOfWork.SaveChangesAsync(cancellationToken);
    return commentSuggestion.Id;
  }
}