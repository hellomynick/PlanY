using PlanY.Presentation.Abstract.CQRS;

namespace PlanY.Presentation.CQRS.Commands.TravelPlanCommand;

public class CreateTravelPlanCommand : ICommand<bool>
{
    public Guid Id { get; set; }
    public string NamePlan { get; set; }
    public string Detail { get; set; }
    public string Location { get; set; }
    public DateTime DateFrom { get; set; }
    public DateTime DateTo { get; set; }
    public decimal Expense { get; set; }
}