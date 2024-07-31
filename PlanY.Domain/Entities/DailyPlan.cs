using System.ComponentModel.DataAnnotations;
using PlanY.Domain.Exceptions;

namespace PlanY.Domain.Entities;

public class DailyPlan : BaseEntity
{
    public DailyPlan(string namePlan, string detail, DateTime date, decimal price)
    {
        NamePlan = !string.IsNullOrEmpty(namePlan) ? namePlan : throw new PlanYDomainException("Name plan must input");
        Detail = detail;
        Date = date;
        Price = price;
    }

    [Required] [MaxLength(50)] public string NamePlan { get; private set; }
    [MaxLength(200)] public string Detail { get; private set; }
    [Required] public DateTime Date { get; private set; }
    [Required] public decimal Price { get; private set; }
}