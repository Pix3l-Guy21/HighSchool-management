using HighSchool.Application.Common.Interfaces;

namespace HighSchool.Application.Features.Profiles.Create;

public sealed record CreateProfileCommand(
    Guid UserId,
    string FirstName,
    string LastName,
    string Phone,
    string Address,
    DateOnly DateOfBirth
) : ICommand<Guid>;