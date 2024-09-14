using MediatR;

namespace PlanY.Presentation.Apis.UserApi;

public class UserService
{
    public UserService(IMediator mediator)
    {
        Mediator = mediator;
    }

    public IMediator Mediator { get; set; }
}