using System.ComponentModel.DataAnnotations;
using PlanY.Domain.Exceptions;

namespace PlanY.Domain.Entities;

public class User : BaseEntity
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
}