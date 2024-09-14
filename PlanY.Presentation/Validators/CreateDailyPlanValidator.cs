using FluentValidation;
using PlanY.Presentation.CQRS.Commands.DailyPlanCommand;

namespace PlanY.Presentation.Validators;

public class CreateDailyPlanValidator : AbstractValidator<CreateDailyPlanCommand>
{
    public CreateDailyPlanValidator()
    {
        RuleFor(dailyPlan => dailyPlan.NamePlan).NotEmpty().WithMessage("Name Plan can't null");
        RuleFor(dailyPlan => dailyPlan.Expense).LessThan(0).WithMessage("Expense can not negative");
    }
}