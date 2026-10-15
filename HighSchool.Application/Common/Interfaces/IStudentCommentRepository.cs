using HighSchool.Domain.Entities;

namespace HighSchool.Application.Common.Interfaces;

public interface IStudentCommentRepository
{
   Task AddAsync(
      StudentComment studentComment,
      CancellationToken cancellationToken);

   Task<Assessment?> GetByIdAsync(
      Guid studentCommentId,
      CancellationToken cancellationToken);
}