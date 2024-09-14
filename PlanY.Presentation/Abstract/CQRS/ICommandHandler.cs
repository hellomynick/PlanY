using MediatR;

namespace PlanY.Presentation.Abstract.CQRS;

public interface
    ICommandHandler<TCommand, TResponse> : IRequestHandler<TCommand, TResponse>
    where TCommand : ICommand<TResponse>
{
}