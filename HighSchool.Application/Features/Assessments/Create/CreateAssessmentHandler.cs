using HighSchool.Application.Common.Interfaces;
using HighSchool.Domain.Common;
using HighSchool.Domain.Entities;

namespace HighSchool.Application.Features.Assessments.Create;

public sealed class CreateAssessmentHandler : ICommandHandler<CreateAssessmentCommand, Guid>
{
    private readonly IAssessmentRepository _assessmentRepository;
    private readonly IUnitOfWork _unitOfWork;

    public CreateAssessmentHandler(
        IAssessmentRepository assessmentRepository,
        IUnitOfWork unitOfWork)
    {
        _assessmentRepository = assessmentRepository;
        _unitOfWork = unitOfWork;
    }
    public async Task<Result<Guid>> Handle(
        CreateAssessmentCommand command,
        CancellationToken cancellationToken)
    {
        var assessmentResult = Assessment.Create(
            Guid.NewGuid(),
            command.CourseId,
            command.TeacherId,
            command.Title,
            command.Type,
            command.Weight,
            command.Date);
        if (!assessmentResult.IsSuccess) return assessmentResult.Error!;

        var assessment = assessmentResult.Value;
        
        await _assessmentRepository.AddAsync(assessment, cancellationToken);
        await _unitOfWork.SaveChangesAsync(cancellationToken);
        return assessment.Id;
    }
}