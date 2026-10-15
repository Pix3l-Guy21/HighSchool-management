using HighSchool.Domain.Entities;

namespace HighSchool.Application.Common.Interfaces;

public interface IStudentGradeRepository
{
   Task AddAsync(
      StudentGrade studentGrade,
      CancellationToken cancellationToken);

   Task<Assessment?> GetByIdAsync(
      Guid studentGradeId,
      CancellationToken cancellationToken);
}