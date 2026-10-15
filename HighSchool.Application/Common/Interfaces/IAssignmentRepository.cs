using HighSchool.Domain.Entities;

namespace HighSchool.Application.Common.Interfaces;

public interface IAssignmentRepository
{
   Task AddAsync(
      Assignment assignment,
      CancellationToken cancellationToken);

   Task<Assessment?> GetByIdAsync(
      Guid assignmentId,
      CancellationToken cancellationToken);
}