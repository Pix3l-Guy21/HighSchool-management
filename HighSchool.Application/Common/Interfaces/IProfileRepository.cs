using HighSchool.Domain.Entities;

namespace HighSchool.Application.Common.Interfaces;

public interface IProfileRepository
{
   Task AddAsync(
      Profile profile,
      CancellationToken cancellationToken);

   Task<Assessment?> GetByIdAsync(
      Guid profileId,
      CancellationToken cancellationToken);
}