using HighSchool.Domain.Entities;

namespace HighSchool.Application.Common.Interfaces;

public interface ICommentSuggestionRepository
{
   Task AddAsync(
      CommentSuggestion commentSuggestion,
      CancellationToken cancellationToken);

   Task<Assessment?> GetByIdAsync(
      Guid commentSuggestionId,
      CancellationToken cancellationToken);
}