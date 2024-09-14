using MediatR;
using PlanY.Infrastructure.Idempotency;

namespace PlanY.Presentation.CQRS.Commands.IdentifiedCommand;

public abstract class
    IdentifiedCommandHandler<TCommand, TResponse> : IRequestHandler<IdentifiedCommand<TCommand, TResponse>, TResponse>
    where TCommand : IRequest<TResponse>
{
    private readonly IMediator _mediator;
    private readonly IRequestManager _requestManager;

    public IdentifiedCommandHandler(IRequestManager requestManager, IMediator mediator)
    {
        _requestManager = requestManager;
        _mediator = mediator;
    }

    public async Task<TResponse> Handle(IdentifiedCommand<TCommand, TResponse> request,
        CancellationToken cancellationToken)
    {
        if (await _requestManager.IsExistRequest(request.Id)) return CreateResultForDuplicateRequest();

        await _requestManager.AddRequest<TCommand>(request.Id);

        return await _mediator.Send(request.Command, cancellationToken);
    }

    protected abstract TResponse CreateResultForDuplicateRequest();
}