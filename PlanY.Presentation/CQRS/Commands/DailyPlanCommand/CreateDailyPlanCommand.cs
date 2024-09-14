using PlanY.Presentation.Abstract.CQRS;

namespace PlanY.Presentation.CQRS.Commands.DailyPlanCommand;

public class CreateDailyPlanCommand : ICommand<bool>
{
    public Guid UserId { get; set; }
    public string NamePlan { get; set; } = "";
    public string Detail { get; set; } = "";
    public DateTime Date { get; set; }
    public decimal Expense { get; set; }
}