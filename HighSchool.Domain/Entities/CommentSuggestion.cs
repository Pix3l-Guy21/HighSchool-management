using HighSchool.Domain.Common;

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
        if (id == Guid.Empty) return new Error("CommentSuggestion.EmptyId", "CommentSuggestion Id cannot be empty.", ErrorType.Conflict);
        if (string.IsNullOrWhiteSpace(category)) return new Error("CommentSuggestion.EmptyCategory", "Comment category cannot be empty.", ErrorType.Conflict);
        if (string.IsNullOrWhiteSpace(templateText)) return new Error("CommentSuggestion.EmptyTemplateText", "Comment template text cannot be empty.", ErrorType.Conflict);
        if (string.IsNullOrWhiteSpace(tone)) return new Error("CommentSuggestion.EmptyTone", "Comment tone cannot be empty.", ErrorType.Conflict);
        return new CommentSuggestion(id, category, templateText, tone);
    }

    public Result Update(string category, string templateText, string tone)
    {
        if (string.IsNullOrWhiteSpace(category)) return new Error("CommentSuggestion.EmptyCategory", "Comment category cannot be empty.", ErrorType.Conflict);
        if (string.IsNullOrWhiteSpace(templateText)) return new Error("CommentSuggestion.EmptyTemplateText", "Comment template text cannot be empty.", ErrorType.Conflict);
        if (string.IsNullOrWhiteSpace(tone)) return new Error("CommentSuggestion.EmptyTone", "Comment tone cannot be empty.", ErrorType.Conflict);
        Category = category;
        TemplateText = templateText;
        Tone = tone;
        return Result.Success();
    }
}