using HighSchool.Application.Common.Interfaces;

namespace HighSchool.Application.Features.CommentSuggestions.Create;

public sealed record CreateCommentSuggestionCommand(
    string Category,
    string TemplateText,
    string Tone
) : ICommand<Guid>;