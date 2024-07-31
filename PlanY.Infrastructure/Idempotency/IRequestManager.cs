namespace PlanY.Infrastructure.Idempotency;

public interface IRequestManager
{
    Task AddRequest(ClientRequest clientRequest);
    Task<bool> IsExistRequest(Guid id);
}