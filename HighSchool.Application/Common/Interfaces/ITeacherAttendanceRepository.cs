using HighSchool.Domain.Entities;

namespace HighSchool.Application.Common.Interfaces;

public interface ITeacherAttendanceRepository
{
   Task AddAsync(
      TeacherAttendance teacherAttendance,
      CancellationToken cancellationToken);

   Task<Assessment?> GetByIdAsync(
      Guid teacherAttendanceId,
      CancellationToken cancellationToken);
}