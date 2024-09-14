using FluentValidation;
using PlanY.Presentation.CQRS.Commands.TravelPlanCommand;

namespace PlanY.Presentation.Validators;

public class CreateTravelPlanValidator : AbstractValidator<CreateTravelPlanCommand>
{
    public CreateTravelPlanValidator()
    {
        RuleFor(travelPlan => travelPlan.NamePlan).NotEmpty().WithMessage("Name plan can't empty");
        RuleFor(travelPlan => travelPlan.DateFrom.Month).GreaterThan(travelPlan => travelPlan.DateTo.Month)
            .WithMessage("Date from can not greater than dateTo");
        RuleFor(travelPlan => travelPlan.DateFrom.Date).GreaterThan(travelPlan => travelPlan.DateTo.Date)
            .When(travelPlan => travelPlan.DateFrom.Month == travelPlan.DateTo.Month)
            .WithMessage("Date from can not greater than date to");
        RuleFor(travelPlan => travelPlan.Location).NotEmpty().WithMessage("Location can't empty");
    }
}