namespace CleanArchitecture.Domain.Common.Bases;

public abstract class ValueObjectBase
{
    protected static bool EqualOperator(ValueObjectBase left, ValueObjectBase right)
    {
        if (left is null ^ right is null)
        {
            return false;
        }

        return left?.Equals(right!) != false;
    }

    protected static bool NotEqualOperator(ValueObjectBase left, ValueObjectBase right)
    {
        return !EqualOperator(left, right);
    }

    protected abstract IEnumerable<object> GetEqualityComponents();

    public override bool Equals(object? obj)
    {
        if (obj == null || obj.GetType() != GetType())
        {
            return false;
        }

        ValueObjectBase other = (ValueObjectBase)obj;
        return GetEqualityComponents().SequenceEqual(other.GetEqualityComponents());
    }

    public override int GetHashCode()
    {
        HashCode hash = new HashCode();

        foreach (object component in GetEqualityComponents())
        {
            hash.Add(component);
        }

        return hash.ToHashCode();
    }
}