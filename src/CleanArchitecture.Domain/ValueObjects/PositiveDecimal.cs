using CleanArchitecture.Domain.Common.Bases;
using CleanArchitecture.Domain.Common.Exceptions;

namespace CleanArchitecture.Domain.ValueObjects;

public class PositiveDecimal : ValueObjectBase
{
    public PositiveDecimal(decimal value)
    {
        SetValue(value);
    }

    public decimal Value { get; set; }

    public static implicit operator decimal(PositiveDecimal positiveDecimal)
    {
        return positiveDecimal.Value;
    }

    private void SetValue(decimal value)
    {
        if (value < 0)
        {
            DomainException.Throw($"The value {value} can not be negative.");
        }

        Value = value;
    }

    protected override IEnumerable<object> GetEqualityComponents()
    {
        yield return Value;
    }
}