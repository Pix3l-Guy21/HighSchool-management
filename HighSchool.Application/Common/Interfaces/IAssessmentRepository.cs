using HighSchool.Domain.Entities;

namespace HighSchool.Application.Common.Interfaces;

public interface IAssessmentRepository
{
    Task AddAsync(
        Assessment assessment,
        CancellationToken cancellationToken);

    Task<Assessment?> GetByIdAsync(
        Guid assessmentId,
        CancellationToken cancellationToken);
}
