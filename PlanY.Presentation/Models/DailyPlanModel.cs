using System.ComponentModel.DataAnnotations;

namespace PlanY.Presentation.Models;

public record DailyPlanModel
{
    public Guid Id { get; set; }
    public string NamePlan { get; set; } = "";
    public string Detail { get; set; } = "";
    public DateTime Date { get; set; }
    public decimal Expense { get; set; }
}