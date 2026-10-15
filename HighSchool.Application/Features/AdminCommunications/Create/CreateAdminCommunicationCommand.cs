using HighSchool.Application.Common.Interfaces;

namespace HighSchool.Application.Features.AdminCommunications.Create;

public sealed record CreateAdminCommunicationCommand(
    Guid SenderId,
    Guid RecipientId,
    string Subject,
    string Message,
    DateTime SentAt
) : ICommand<Guid>;