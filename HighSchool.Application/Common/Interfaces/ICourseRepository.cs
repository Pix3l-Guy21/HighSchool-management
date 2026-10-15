using HighSchool.Domain.Entities;

namespace HighSchool.Application.Common.Interfaces;

public interface ICourseRepository
{
   Task AddAsync(
      Course course,
      CancellationToken cancellationToken);

   Task<Assessment?> GetByIdAsync(
      Guid courseId,
      CancellationToken cancellationToken);
}