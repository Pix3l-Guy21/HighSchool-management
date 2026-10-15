using HighSchool.Application.Common.Interfaces;
using HighSchool.Domain.Common;
using HighSchool.Domain.Entities;

namespace HighSchool.Application.Features.Profiles.Create;

public sealed class CreateProfileHandler : ICommandHandler<CreateProfileCommand, Guid>
{
    private readonly IProfileRepository _profileRepository;
    private readonly IUnitOfWork _unitOfWork;

    public CreateProfileHandler(
        IProfileRepository profileRepository,
        IUnitOfWork unitOfWork)
    {
        _profileRepository = profileRepository;
        _unitOfWork = unitOfWork;
    }
    public async Task<Result<Guid>> Handle(
        CreateProfileCommand command,
        CancellationToken cancellationToken)
    {
        var profileResult = Profile.Create(
            Guid.NewGuid(),
            command.UserId,
            command.FirstName,
            command.LastName,
            command.Phone,
            command.Address,
            command.DateOfBirth
        );
        if (!profileResult.IsSuccess) return profileResult.Error!;

        var profile = profileResult.Value;

        await _profileRepository.AddAsync(profile, cancellationToken);
        await _unitOfWork.SaveChangesAsync(cancellationToken);
        return profile.Id;
    }
}