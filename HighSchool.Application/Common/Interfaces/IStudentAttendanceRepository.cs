using HighSchool.Domain.Entities;

namespace HighSchool.Application.Common.Interfaces;

public interface IStudentAttendanceRepository
{
   Task AddAsync(
      StudentAttendance studentAttendance,
      CancellationToken cancellationToken);

   Task<Assessment?> GetByIdAsync(
      Guid studentAttendanceId,
      CancellationToken cancellationToken);
}