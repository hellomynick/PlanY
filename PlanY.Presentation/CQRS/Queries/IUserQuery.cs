using PlanY.Presentation.Abstract.CQRS;

namespace PlanY.Presentation.CQRS.Queries;

public interface IUserQuery : IQuery<UserViewModel>
{
    Task<UserViewModel?> GetUserById(Guid id);
    Task<IEnumerable<UserViewModel>?> GetListUser();
}