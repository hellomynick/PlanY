using System.ComponentModel.DataAnnotations;
using PlanY.Domain.Concreted;
using PlanY.Domain.Exceptions;

namespace PlanY.Domain.Entities;

public class User : BaseEntity<Guid>
{
    public User(string identityGuid, string name)
    {
        IdentityGuid = !string.IsNullOrEmpty(identityGuid)
            ? identityGuid
            : throw new PlanYDomainException("Id cannot null");
        Name = !string.IsNullOrEmpty(name) ? name : throw new PlanYDomainException("User name cannot null");
    }

    [Required] public string IdentityGuid { get; private set; }
    [Required] public string Name { get; private set; }
    public ICollection<DailyPlan> DailyPlans { get; set; }
    public ICollection<TravelPlan> TravelPlans { get; set; }
}