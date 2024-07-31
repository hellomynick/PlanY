using System.ComponentModel.DataAnnotations;
using PlanY.Domain.Concreted;
using PlanY.Domain.Exceptions;

namespace PlanY.Domain.Entities;

public class TravelPlan : BaseEntity
{
    public TravelPlan(string location, DateTime dateFrom, DateTime dateTo, string detail, decimal price,
        string namePlan)
    {
        NamePlan = !string.IsNullOrEmpty(namePlan) ? namePlan : throw new PlanYDomainException("Name plan must input");
        Location = location;
        DateFrom = dateFrom;
        DateTo = dateTo;
        Detail = detail;
        Price = decimal.IsPositive(price) ? price : throw new PlanYDomainException("Price can not negative");
    }

    [Required] [MaxLength(50)] public string NamePlan { get; private set; }
    [MaxLength(200)] public string Detail { get; private set; }
    [MaxLength(50)] public string Location { get; private set; }
    [Required] public DateTime DateFrom { get; private set; }
    [Required] public DateTime DateTo { get; private set; }
    [Required] public decimal Price { get; private set; }
}