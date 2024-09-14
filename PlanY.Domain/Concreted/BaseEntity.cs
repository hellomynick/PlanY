namespace PlanY.Domain.Concreted;

public abstract class BaseEntity<T>
{
    private int? _requestedHashCode;

    public virtual T Id { get; protected set; }

    public DateTime DateCreated { get; set; }
    public DateTime DateUpdated { get; set; }

    public bool IsTransient()
    {
        return Id.Equals(default(T));
    }

    public override bool Equals(object? obj)
    {
        if (obj is not BaseEntity<T> entity)
            return false;

        if (ReferenceEquals(this, entity))
            return true;

        if (GetType() != entity.GetType())
            return false;

        if (entity.IsTransient() || IsTransient())
            return false;
        return entity.Id.Equals(Id);
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

    public static bool operator ==(BaseEntity<T>? left, BaseEntity<T>? right)
    {
        return left?.Equals(right) ?? Equals(right, null);
    }

    public static bool operator !=(BaseEntity<T> left, BaseEntity<T> right)
    {
        return left != right;
    }
}