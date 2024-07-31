using System.ComponentModel.DataAnnotations;

namespace PlanY.Infrastructure.Idempotency;

public class ClientRequest
{
    public ClientRequest(Guid id, string name, TimeOnly time)
    {
        Id = id;
        Name = name;
        Time = time;
    }

    public Guid Id { get; set; }
    [MaxLength(50)] public required string Name { get; set; }
    public TimeOnly Time { get; set; }
}