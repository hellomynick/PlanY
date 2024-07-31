namespace PlanY.Domain.Entities;

public abstract class BaseEntity
{
    private int? _requestedHashCode;

    public virtual long Id { get; protected set; }

    public required DateTime DateCreated { get; set; }
    public required DateTime DateUpdated { get; set; }

    public bool IsTransient()
    {
        return Id == 0;
    }

    public override bool Equals(object? obj)
    {
        if (obj is not BaseEntity entity)
            return false;

        if (ReferenceEquals(this, entity))
            return true;

        if (GetType() != entity.GetType())
            return false;

        if (entity.IsTransient() || IsTransient())
            return false;
        return entity.Id == Id;
    }

    public override int GetHashCode()
    {
        if (!IsTransient())
        {
            if (!_requestedHashCode.HasValue)
                _requestedHashCode =
                    Id.GetHashCode() ^
                    31; // XOR for random distribution (http://blogs.msdn.com/b/ericlippert/archive/2011/02/28/guidelines-and-rules-for-gethashcode.aspx)

            return _requestedHashCode.Value;
        }

        return base.GetHashCode();
    }

    public static bool operator ==(BaseEntity left, BaseEntity right)
    {
        return left?.Equals(right) ?? Equals(right, null);
    }

    public static bool operator !=(BaseEntity left, BaseEntity right)
    {
        return left != right;
    }
}