namespace PlanY.Infrastructure.Idempotency;

public class RequestManager : IRequestManager
{
    private readonly PlanYDbContext _context;

    public RequestManager(PlanYDbContext context)
    {
        _context = context ?? throw new ArgumentNullException(nameof(context));
    }

    private async Task<Guid?> FindByIdAsync(Guid id)
    {
        var request = await _context.ClientRequests.FindAsync(id);
        return request?.Id;
    }

    public async Task AddRequest(ClientRequest clientRequest)
    {
        if (await IsExistRequest(clientRequest.Id)) throw new Exception("request is exist");
        await _context.ClientRequests.AddAsync(clientRequest);
    }

    public async Task<bool> IsExistRequest(Guid id)
    {
        var request = await FindByIdAsync(id);
        return request != null;
    }
}