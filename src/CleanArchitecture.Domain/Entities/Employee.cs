using CleanArchitecture.Domain.Common.Bases;
using CleanArchitecture.Domain.Common.Exceptions;

namespace CleanArchitecture.Domain.Entities;

public class Employee : EntityBase
{
    private Employee(string name, string email)
    {
        SetName(name);
        SetEmail(email);
        Active();
        IsDeleted = false;
    }

    public string Name { get; private set; }
    public string Email { get; private set; }
    public bool IsActive { get; private set; }
    public bool IsDeleted { get; private set; }

    public static Employee CreateInstance(string name, string email)
    {
        return new Employee(name, email);
    }

    public void SetName(string name)
    {
        if (string.IsNullOrWhiteSpace(name))
        {
            DomainException.Throw("Name is required.");
        }

        Name = name;
    }

    public void SetEmail(string email)
    {
        Email = email;
    }

    public void Active()
    {
        IsActive = true;
    }

    public void Desactive()
    {
        IsActive = false;
    }

    public void Delete()
    {
        IsDeleted = true;
    }
}