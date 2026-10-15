using HighSchool.Application.Common.Interfaces;

namespace HighSchool.Application.Features.Classes.Create;

public sealed record CreateClassCommand (
    string Name,
    string AcademicYear,
    Guid HomeRoomTeacherId
) : ICommand<Guid>;