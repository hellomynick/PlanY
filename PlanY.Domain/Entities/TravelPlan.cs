using System.ComponentModel.DataAnnotations;
using PlanY.Domain.Concreted;
using PlanY.Domain.Exceptions;

namespace PlanY.Domain.Entities;

public class TravelPlan : BaseEntity<long>
{
    public TravelPlan(Guid userId, string namePlan, string location, DateTime dateFrom, DateTime dateTo, string detail,
        decimal expense)
    {
        NamePlan = !string.IsNullOrEmpty(namePlan) ? namePlan : throw new PlanYDomainException("Name plan must input");
        Location = location;
        DateFrom = dateFrom;
        DateTo = dateTo;
        Detail = detail;
        UserId = userId;
        Expense = decimal.IsPositive(expense) ? expense : throw new PlanYDomainException("Price can not negative");
    }

    [Required] public Guid UserId { get; set; }
    public User User { get; set; }
    [Required] [MaxLength(50)] public string NamePlan { get; private set; }
    [MaxLength(200)] public string Detail { get; private set; }
    [MaxLength(50)] public string Location { get; private set; }
    [Required] public DateTime DateFrom { get; private set; }
    [Required] public DateTime DateTo { get; private set; }
    [Required] public decimal Expense { get; private set; }
}