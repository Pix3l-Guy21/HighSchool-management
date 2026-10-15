using HighSchool.Application.Common.Interfaces;
using HighSchool.Domain.Common;
using HighSchool.Domain.Entities;

namespace HighSchool.Application.Features.StudentGrades.Create;

public sealed class CreateStudentGradeHandler : ICommandHandler<CreateStudentGradeCommand, Guid>
{
    private readonly IStudentGradeRepository _studentGradeRepository;
    private readonly IUnitOfWork _unitOfWork;

    public CreateStudentGradeHandler(
        IStudentGradeRepository studentGradeRepository,
        IUnitOfWork unitOfWork)
    {
        _studentGradeRepository = studentGradeRepository;
        _unitOfWork = unitOfWork;
    }
    public async Task<Result<Guid>> Handle(
        CreateStudentGradeCommand command,
        CancellationToken cancellationToken)
    {
        var studentGradeResult = StudentGrade.Create(
            Guid.NewGuid(),
            command.CourseId,
            command.StudentId,
            command.AssignmentId,
            command.AssessmentId,
            command.Title,
            command.Feedback,
            command.Score,
            command.GradedDate
        );
        if (!studentGradeResult.IsSuccess) return studentGradeResult.Error!;

        var studentGrade = studentGradeResult.Value;

        await _studentGradeRepository.AddAsync(studentGrade, cancellationToken);
        await _unitOfWork.SaveChangesAsync(cancellationToken);
        return studentGrade.Id;
    }
}