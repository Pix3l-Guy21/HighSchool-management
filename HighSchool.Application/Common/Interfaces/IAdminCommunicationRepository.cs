using HighSchool.Domain.Entities;

namespace HighSchool.Application.Common.Interfaces;

public interface IAdminCommunicationRepository
{
   Task AddAsync(
      AdminCommunication adminCommunication,
      CancellationToken cancellationToken);

   Task<Assessment?> GetByIdAsync(
      Guid adminCommunicationId,
      CancellationToken cancellationToken);
}