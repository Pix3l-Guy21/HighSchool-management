using HighSchool.Application.Common.Interfaces;
using HighSchool.Domain.Common;
using HighSchool.Domain.Entities;

namespace HighSchool.Application.Features.Users.Create;

public sealed class CreateUserHandler : ICommandHandler<CreateUserCommand, Guid>
{
  private readonly IUserRepository _userRepository;
  private readonly IUnitOfWork _unitOfWork;

  public CreateUserHandler(
    IUserRepository userRepository,
    IUnitOfWork unitOfWork)
  {
    _userRepository = userRepository;
    _unitOfWork = unitOfWork;
  }
  public async Task<Result<Guid>> Handle(
    CreateUserCommand command,
    CancellationToken cancellationToken)
  {
    var userResult = User.Create(
      Guid.NewGuid(),
      command.Username,
      command.PasswordHash,
      command.Role,
      command.Email
    );
    if (!userResult.IsSuccess) return userResult.Error!;

    var user = userResult.Value;

    await _userRepository.AddAsync(user, cancellationToken);
    await _unitOfWork.SaveChangesAsync(cancellationToken);
    return user.Id;
  }
}