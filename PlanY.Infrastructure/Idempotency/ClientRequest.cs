namespace PlanY.Infrastructure.Idempotency;

public class ClientRequest
{
    public ClientRequest(Guid id, string name, DateTime dateTime)
    {
        Id = id;
        Name = name;
        DateTime = dateTime;
    }

    public Guid Id { get; set; }
    public string Name { get; set; }
    public DateTime DateTime { get; set; }
}