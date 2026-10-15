using HighSchool.Application.Common.Interfaces;
using HighSchool.Domain.Common;
using HighSchool.Domain.Entities;

namespace HighSchool.Application.Features.Assignments.Create;

public sealed class CreateAssignmentHandler : ICommandHandler<CreateAssignmentCommand, Guid>
{
   private readonly IAssignmentRepository _assignmentRepository;
   private readonly IUnitOfWork _unitOfWork;

   public CreateAssignmentHandler(
      IAssignmentRepository assignmentRepository,
      IUnitOfWork unitOfWork)
   {
      _assignmentRepository = assignmentRepository;
      _unitOfWork = unitOfWork;
   }
   public async Task<Result<Guid>> Handle(
      CreateAssignmentCommand command,
      CancellationToken cancellationToken)
   {
      var assignmentResult = Assignment.Create(
         Guid.NewGuid(),
         command.CourseId,
         command.TeacherId,
         command.Title,
         command.Description,
         command.TotalPoint,
         command.DueDate
      );
      if (!assignmentResult.IsSuccess) return assignmentResult.Error!;

      var assignment = assignmentResult.Value;

      await _assignmentRepository.AddAsync(assignment, cancellationToken);
      await _unitOfWork.SaveChangesAsync(cancellationToken);
      return assignment.Id;
   }
}