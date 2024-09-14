using MediatR;
using PlanY.Domain.Entities;
using PlanY.Infrastructure.Idempotency;
using PlanY.Presentation.Abstract.CQRS;
using PlanY.Presentation.CQRS.Commands.IdentifiedCommand;
using PlanY.UseCase.Repositories;

namespace PlanY.Presentation.CQRS.Commands.UserCommand;

public class CreateUserCommandHandler : ICommandHandler<CreateUserCommand, bool>
{
    private readonly IUserRepository _userRepository;

    public CreateUserCommandHandler(IUserRepository userRepository)
    {
        _userRepository = userRepository ?? throw new ArgumentNullException(nameof(userRepository));
    }

    public async Task<bool> Handle(CreateUserCommand request, CancellationToken cancellationToken)
    {
        var user = new User(request.Id.ToString(), request.Name);
        await _userRepository.AddAsync(user);

        return await _userRepository.UnitOfWork.SaveChangesAsync(cancellationToken);
    }
}

public class CreateUserIdentifiedCommandHandler : IdentifiedCommandHandler<CreateUserCommand, bool>
{
    public CreateUserIdentifiedCommandHandler(IRequestManager requestManager, IMediator mediator) : base(requestManager,
        mediator)
    {
    }

    protected override bool CreateResultForDuplicateRequest()
    {
        return true;
    }
}