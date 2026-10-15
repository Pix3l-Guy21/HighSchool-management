using HighSchool.Domain.Entities;

namespace HighSchool.Application.Common.Interfaces;

public interface ITeacherRepository
{
   Task AddAsync(
      Teacher teacher,
      CancellationToken cancellationToken);

   Task<Assessment?> GetByIdAsync(
      Guid teacherId,
      CancellationToken cancellationToken);
}