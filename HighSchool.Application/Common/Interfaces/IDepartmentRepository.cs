using HighSchool.Domain.Entities;

namespace HighSchool.Application.Common.Interfaces;

public interface IDepartmentRepository
{
   Task AddAsync(
      Department department,
      CancellationToken cancellationToken);

   Task<Assessment?> GetByIdAsync(
      Guid departmentId,
      CancellationToken cancellationToken);
}