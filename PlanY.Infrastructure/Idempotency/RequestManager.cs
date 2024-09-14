namespace PlanY.Infrastructure.Idempotency;

public class RequestManager : IRequestManager
{
    private readonly PlanYDbContext _context;

    public RequestManager(PlanYDbContext context)
    {
        _context = context ?? throw new ArgumentNullException(nameof(context));
    }

    public async Task<bool> IsExistRequest(Guid id)
    {
        var request = await FindByIdAsync(id);
        return request != null;
    }

    private async Task<Guid?> FindByIdAsync(Guid id)
    {
        var request = await _context.ClientRequests.FindAsync(id);
        return request?.Id;
    }

    public async Task AddRequest<T>(Guid id)
    {
        if (await IsExistRequest(id)) throw new Exception("request is exist");

        var clientRequest = new ClientRequest(id, nameof(T), DateTime.UtcNow);

        await _context.ClientRequests.AddAsync(clientRequest);
    }
}