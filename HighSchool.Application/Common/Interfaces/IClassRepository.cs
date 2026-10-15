using HighSchool.Domain.Entities;

namespace HighSchool.Application.Common.Interfaces;

public interface IClassRepository
{
   Task AddAsync(
      Class classRoom,
      CancellationToken cancellationToken);

   Task<Assessment?> GetByIdAsync(
      Guid classId,
      CancellationToken cancellationToken);
}