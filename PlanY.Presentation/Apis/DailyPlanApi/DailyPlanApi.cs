using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using PlanY.Presentation.CQRS.Commands.DailyPlanCommand;
using PlanY.Presentation.CQRS.Commands.IdentifiedCommand;

namespace PlanY.Presentation.Apis.DailyPlanApi;

public static class DailyPlanApi
{
    public static RouteGroupBuilder MapDailyPlanV1(this IEndpointRouteBuilder app)
    {
        var api = app.MapGroup("api/plan/daily-plan");

        api.MapPost("/", CreateDailyPlanAsync);

        return api;
    }

    public static async Task<Results<Ok, BadRequest<string>, ProblemHttpResult>> CreateDailyPlanAsync(
        [FromHeader(Name = "x-requestid")] Guid requestId,
        CreateDailyPlanCommand createDailyPlanCommand,
        [AsParameters] DailyPlanService service
    )
    {
        if (requestId == Guid.Empty) return TypedResults.BadRequest("Empty GUID is not valid for request ID");

        var requestCreatePlanDaily =
            new IdentifiedCommand<CreateDailyPlanCommand, bool>(createDailyPlanCommand, requestId);

        var result = await service.Mediator.Send(requestCreatePlanDaily);

        return TypedResults.Ok();
    }
}