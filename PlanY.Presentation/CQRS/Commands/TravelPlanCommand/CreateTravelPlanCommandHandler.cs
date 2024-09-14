using MediatR;
using PlanY.Domain.Entities;
using PlanY.Infrastructure.Idempotency;
using PlanY.Presentation.Abstract.CQRS;
using PlanY.Presentation.CQRS.Commands.IdentifiedCommand;
using PlanY.UseCase.Repositories;

namespace PlanY.Presentation.CQRS.Commands.TravelPlanCommand;

public class CreateTravelPlanCommandHandler : ICommandHandler<CreateTravelPlanCommand, bool>
{
    private readonly ITravelPlanRepository _travelPlanRepository;

    public CreateTravelPlanCommandHandler(ITravelPlanRepository travelPlanRepository)
    {
        _travelPlanRepository = travelPlanRepository ?? throw new ArgumentNullException(nameof(travelPlanRepository));
    }

    public async Task<bool> Handle(CreateTravelPlanCommand request,
        CancellationToken cancellationToken)
    {
        var travelPlan = new TravelPlan(Guid.NewGuid(), request.NamePlan, request.Location, request.DateFrom,
            request.DateTo,
            request.Detail,
            request.Expense
        );
        await _travelPlanRepository.AddAsync(travelPlan);

        return await _travelPlanRepository.UnitOfWork.SaveChangesAsync(cancellationToken);
    }
}

public class CreateTravelPlanIdentifiedCommandHandler : IdentifiedCommandHandler<CreateTravelPlanCommand, bool>
{
    public CreateTravelPlanIdentifiedCommandHandler(IRequestManager requestManager, IMediator mediator) : base(
        requestManager, mediator)
    {
    }

    protected override bool CreateResultForDuplicateRequest()
    {
        return true;
    }
}