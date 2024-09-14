using MediatR;

namespace PlanY.Presentation.Apis.DailyPlanApi;

public class DailyPlanService
{
    public DailyPlanService(IMediator mediator)
    {
        Mediator = mediator;
    }

    public IMediator Mediator { get; set; }
}