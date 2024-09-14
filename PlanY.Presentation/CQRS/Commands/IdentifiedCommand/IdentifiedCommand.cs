using MediatR;

namespace PlanY.Presentation.CQRS.Commands.IdentifiedCommand;

public class IdentifiedCommand<T, R> : IRequest<R>
    where T : IRequest<R>
{
    public IdentifiedCommand(T command, Guid id)
    {
        Command = command;
        Id = id;
    }

    public Guid Id { get; }
    public T Command { get; }
}