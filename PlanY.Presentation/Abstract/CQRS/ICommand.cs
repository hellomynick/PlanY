using MediatR;

namespace PlanY.Presentation.Abstract.CQRS;

public interface ICommand<out TResponse> : IRequest<TResponse>
{
}