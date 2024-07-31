namespace PlanY.Domain.Enums;

[Flags]
public enum DateTypes
{
    DailyInWeek = 0,
    EveryWeekInMonth = 1,
    EveryMonthInYear = 2
}