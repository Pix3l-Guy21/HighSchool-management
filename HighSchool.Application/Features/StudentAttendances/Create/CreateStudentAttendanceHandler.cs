using HighSchool.Application.Common.Interfaces;
using HighSchool.Domain.Common;
using HighSchool.Domain.Entities;

namespace HighSchool.Application.Features.StudentAttendances.Create;

public sealed class CreateStudentAttendanceHandler : ICommandHandler<CreateStudentAttendanceCommand, Guid>
{
    private readonly IStudentAttendanceRepository _studentAttendanceRepository;
    private readonly IUnitOfWork _unitOfWork;

    public CreateStudentAttendanceHandler(
        IStudentAttendanceRepository studentAttendanceRepository,
        IUnitOfWork unitOfWork)
    {
        _studentAttendanceRepository = studentAttendanceRepository;
        _unitOfWork = unitOfWork;
    }
    public async Task<Result<Guid>> Handle(
        CreateStudentAttendanceCommand command,
        CancellationToken cancellationToken)
    {
        var studentAttendanceResult = StudentAttendance.Create(
            Guid.NewGuid(),
            command.StudentId,
            command.CourseId,
            command.Date,
            command.Status,
            command.RecordedBy,
            command.Note
        );
        if (!studentAttendanceResult.IsSuccess) return studentAttendanceResult.Error!;

        var studentAttendance = studentAttendanceResult.Value;

        await _studentAttendanceRepository.AddAsync(studentAttendance, cancellationToken);
        await _unitOfWork.SaveChangesAsync(cancellationToken);
        return studentAttendance.Id;
    }
}