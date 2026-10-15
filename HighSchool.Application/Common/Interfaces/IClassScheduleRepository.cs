using HighSchool.Domain.Entities;

namespace HighSchool.Application.Common.Interfaces;

public interface IClassScheduleRepository
{
   Task AddAsync(
      ClassSchedule classSchedule,
      CancellationToken cancellationToken);

   Task<Assessment?> GetByIdAsync(
      Guid classScheduleId,
      CancellationToken cancellationToken);
}