using PlanY.UseCase.Repositories;

namespace PlanY.Presentation.CQRS.Queries;

public class UserQuery : IUserQuery
{
    private readonly IUserRepository _userRepository;

    public UserQuery(IUserRepository userRepository)
    {
        _userRepository = userRepository;
    }

    public async Task<UserViewModel?> GetUserById(Guid id)
    {
        var user = await _userRepository.GetUserByIdAsync(id);
        if (user == null) return null;

        var userViewModel = new UserViewModel
        {
            Id = user.Id,
            Name = user.Name
        };

        return userViewModel;
    }

    public async Task<IEnumerable<UserViewModel>?> GetListUser()
    {
        var listUser = await _userRepository.GetListUserAsync();
        return listUser == null
            ? []
            : listUser.Select(user => new UserViewModel { Id = user.Id, Name = user.Name }).ToList();
    }
}