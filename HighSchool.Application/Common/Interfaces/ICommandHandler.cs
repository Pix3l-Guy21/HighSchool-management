using HighSchool.Domain.Common;

namespace HighSchool.Application.Common.Interfaces;

public interface ICommandHandler<TCommand, TResult> where TCommand : ICommand<TResult>
{
    Task<Result<TResult>> Handle(
        TCommand command,
        CancellationToken cancellationToken);
}