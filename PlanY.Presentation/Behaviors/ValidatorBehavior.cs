using FluentValidation;
using MediatR;
using PlanY.Domain.Exceptions;
using PlanY.Presentation.Abstract.CQRS;

namespace PlanY.Presentation.Behaviors;

public class ValidatorBehavior<TRequest, TResponse> : IPipelineBehavior<TRequest, TResponse>
    where TRequest : ICommand<TResponse>
{
    private readonly IEnumerable<IValidator<TRequest>> _validators;

    public ValidatorBehavior(IEnumerable<IValidator<TRequest>> validators)
    {
        _validators = validators;
    }

    public async Task<TResponse> Handle(TRequest request, RequestHandlerDelegate<TResponse> next,
        CancellationToken cancellationToken)
    {
        var failures = _validators
            .Select(v => v.Validate(request))
            .SelectMany(v => v.Errors)
            .Where(e => e != null)
            .ToList();

        if (failures.Count != 0)
            throw new PlanYDomainException($"Command validation Error for type: {typeof(TRequest).Name}",
                new ValidationException("Validation exception:", failures));

        return await next();
    }
}