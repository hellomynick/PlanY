using MediatR;
using PlanY.Domain.Entities;
using PlanY.Infrastructure.Idempotency;
using PlanY.Presentation.Abstract.CQRS;
using PlanY.Presentation.CQRS.Commands.IdentifiedCommand;
using PlanY.UseCase.Repositories;

namespace PlanY.Presentation.CQRS.Commands.DailyPlanCommand;

public class CreateDailyPlanCommandHandler : ICommandHandler<CreateDailyPlanCommand, bool>
{
    private readonly IDailyPlanRepository _dailyPlanRepository;

    public CreateDailyPlanCommandHandler(IDailyPlanRepository dailyPlanRepository)
    {
        _dailyPlanRepository = dailyPlanRepository ?? throw new ArgumentNullException(nameof(dailyPlanRepository));
    }

    public async Task<bool> Handle(CreateDailyPlanCommand request,
        CancellationToken cancellationToken)
    {
        var dailyPlan = new DailyPlan(request.UserId, request.NamePlan, request.Detail, request.Date,
            request.Expense);
        await _dailyPlanRepository.AddAsync(dailyPlan);

        return await _dailyPlanRepository.UnitOfWork.SaveChangesAsync(cancellationToken);
    }
}

public class CreateDailyPlanIdentifiedCommandHandler : IdentifiedCommandHandler<CreateDailyPlanCommand, bool>
{
    public CreateDailyPlanIdentifiedCommandHandler(IRequestManager requestManager, IMediator mediator) : base(
        requestManager, mediator)
    {
    }

    protected override bool CreateResultForDuplicateRequest()
    {
        return true;
    }
}