namespace PlanY.Presentation.Models;

public record TravelPlanModel
{
    public Guid Id { get; set; }
    public string NamePlan { get; set; } = "";
    public string Detail { get; set; } = "";
    public DateTime DateFrom { get; set; }
    public DateTime DateTo { get; set; }
    public decimal Expense { get; set; }
}