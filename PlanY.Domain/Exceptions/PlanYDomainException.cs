namespace PlanY.Domain.Exceptions;

public class PlanYDomainException : Exception
{
    public PlanYDomainException()
    {
    }

    public PlanYDomainException(string mess) : base(mess)
    {
    }

    public PlanYDomainException(string mess, Exception exception) : base(mess, exception)
    {
    }
}