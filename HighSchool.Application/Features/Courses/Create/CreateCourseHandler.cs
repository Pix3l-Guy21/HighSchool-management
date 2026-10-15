using HighSchool.Application.Common.Interfaces;
using HighSchool.Domain.Common;
using HighSchool.Domain.Entities;

namespace HighSchool.Application.Features.Courses.Create;

public sealed class CreateCourseHandler : ICommandHandler<CreateCourseCommand, Guid>
{
    private readonly ICourseRepository _courseRepository;
    private readonly IUnitOfWork _unitOfWork;

    public CreateCourseHandler(
        ICourseRepository courseRepository,
        IUnitOfWork unitOfWork)
    {
        _courseRepository = courseRepository;
        _unitOfWork = unitOfWork;
    }
    public async Task<Result<Guid>> Handle(
        CreateCourseCommand command,
        CancellationToken cancellationToken)
    {
        var courseResult = Course.Create(
            Guid.NewGuid(),
            command.Name,
            command.Code,
            command.DepartmentId,
            command.Description
        );
        if (!courseResult.IsSuccess) return courseResult.Error!;

        var course = courseResult.Value;

        await _courseRepository.AddAsync(course, cancellationToken);
        await _unitOfWork.SaveChangesAsync(cancellationToken);
        return course.Id;
    }
}