using HighSchool.Domain.Entities;

namespace HighSchool.Application.Common.Interfaces;

public interface IUserRepository
{
   Task AddAsync(
      User user,
      CancellationToken cancellationToken);

   Task<Assessment?> GetByIdAsync(
      Guid userId,
      CancellationToken cancellationToken);
}