using PlanY.Presentation.Abstract.CQRS;

namespace PlanY.Presentation.CQRS.Commands.UserCommand;

public class CreateUserCommand : ICommand<bool>
{
    public Guid Id { get; set; }
    public string Name { get; set; }
}