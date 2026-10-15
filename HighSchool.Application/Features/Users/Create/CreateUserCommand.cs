using HighSchool.Application.Common.Interfaces;

namespace HighSchool.Application.Features.Users.Create;

public sealed record CreateUserCommand(
    string Username,
    string PasswordHash,
    string Role,
    string Email,
    DateTime CreatedAt,
    DateTime UpdatedAt
) : ICommand<Guid>;