using System.ComponentModel.DataAnnotations;
using PlanY.Domain.Concreted;
using PlanY.Domain.Exceptions;

namespace PlanY.Domain.Entities;

public class DailyPlan : BaseEntity<long>
{
    public DailyPlan(Guid userId, string namePlan, string detail, DateTime date, decimal expense)
    {
        UserId = userId;
        NamePlan = !string.IsNullOrEmpty(namePlan) ? namePlan : throw new PlanYDomainException("Name plan must input");
        Detail = detail;
        Date = date;
        Expense = expense;
    }

    [Required] public Guid UserId { get; set; }
    public User User { get; set; }

    [Required] [MaxLength(50)] public string NamePlan { get; private set; }
    [MaxLength(200)] public string Detail { get; private set; }
    [Required] public DateTime Date { get; private set; }
    [Required] public decimal Expense { get; private set; }
}