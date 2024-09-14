using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using PlanY.Presentation.CQRS.Commands.IdentifiedCommand;
using PlanY.Presentation.CQRS.Commands.UserCommand;
using PlanY.Presentation.CQRS.Queries;

namespace PlanY.Presentation.Apis.UserApi;

public static class UserApi
{
    public static RouteGroupBuilder MapUserApiV1(this IEndpointRouteBuilder app)
    {
        var api = app.MapGroup("api/user");

        api.MapPost("/", CreateUserAsync);
        api.MapGet("/{id:guid}", GetUserById);
        api.MapGet("/list", GetListUser);

        return api;
    }

    public static async Task<Results<Ok<string>, BadRequest<string>, ProblemHttpResult>> CreateUserAsync(
        [FromHeader(Name = "x-requestid")] Guid requestId,
        CreateUserCommand createUserCommand,
        [AsParameters] UserService service
    )
    {
        if (requestId == Guid.Empty) return TypedResults.BadRequest("Empty GUID is not valid for request ID");

        var requestCreateUser = new IdentifiedCommand<CreateUserCommand, bool>(createUserCommand, requestId);
        await service.Mediator.Send(requestCreateUser);

        return TypedResults.Ok<string>("Request success");
    }

    public static async Task<Results<Ok<UserViewModel>, NotFound>> GetUserById(
        Guid id,
        [FromServices] IUserQuery userQuery
    )
    {
        var user = await userQuery.GetUserById(id);

        return user != null ? TypedResults.Ok(user) : TypedResults.NotFound();
    }

    public static async Task<Results<Ok<IEnumerable<UserViewModel>>, NotFound>> GetListUser(
        [FromServices] IUserQuery userQuery
    )
    {
        var user = await userQuery.GetListUser();

        return user != null ? TypedResults.Ok(user) : TypedResults.NotFound();
    }
}