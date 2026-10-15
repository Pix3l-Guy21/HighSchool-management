using HighSchool.Domain.Entities;

namespace HighSchool.Application.Common.Interfaces;

public interface IStudentRepository
{
   Task AddAsync(
      Student student,
      CancellationToken cancellationToken);

   Task<Assessment?> GetByIdAsync(
      Guid studentId,
      CancellationToken cancellationToken);
}