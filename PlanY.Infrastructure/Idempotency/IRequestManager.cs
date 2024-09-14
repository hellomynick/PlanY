namespace PlanY.Infrastructure.Idempotency;

public interface IRequestManager
{
    Task AddRequest<T>(Guid id);
    Task<bool> IsExistRequest(Guid id);
}