using HighSchool.Domain.Common;
using HighSchool.Domain.Errors;

namespace HighSchool.Domain.Entities;

public class CommentSuggestion
{
    public Guid Id { get; private set; }
    public string Category { get; private set; } = string.Empty;
    public string TemplateText { get; private set; } = string.Empty;
    public string Tone { get; private set; } = string.Empty;

    private CommentSuggestion() { }

    private CommentSuggestion(Guid id, string category, string templateText, string tone)
    {
        Id = id;
        Category = category;
        TemplateText = templateText;
        Tone = tone;
    }

    public static Result<CommentSuggestion> Create(Guid id, string category, string templateText, string tone)
    {
        if (id == Guid.Empty) return CommentSuggestionErrors.EmptyId;
        if (string.IsNullOrWhiteSpace(category)) return CommentSuggestionErrors.EmptyCategory;
        if (string.IsNullOrWhiteSpace(templateText)) return CommentSuggestionErrors.EmptyTemplateText;
        if (string.IsNullOrWhiteSpace(tone)) return CommentSuggestionErrors.EmptyTone;
        return new CommentSuggestion(id, category, templateText, tone);
    }

    public Result Update(string category, string templateText, string tone)
    {
        if (string.IsNullOrWhiteSpace(category)) return CommentSuggestionErrors.EmptyCategory;
        if (string.IsNullOrWhiteSpace(templateText)) return CommentSuggestionErrors.EmptyTemplateText;
        if (string.IsNullOrWhiteSpace(tone)) return CommentSuggestionErrors.EmptyTone;
        Category = category;
        TemplateText = templateText;
        Tone = tone;
        return Result.Success();
    }
}