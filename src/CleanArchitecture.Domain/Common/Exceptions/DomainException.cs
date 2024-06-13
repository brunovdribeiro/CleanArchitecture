namespace CleanArchitecture.Domain.Common.Exceptions;

public class DomainException(string message) : Exception($"Domain Exception: {message}")
{
    public static void Throw(string message)
    {
        throw new DomainException(message);
    }
}