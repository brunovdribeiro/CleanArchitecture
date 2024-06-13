using System.ComponentModel.DataAnnotations.Schema;

namespace CleanArchitecture.Domain.Common.Bases;

public abstract class EntityBase
{
    private readonly List<EventBase> _domainEvents = new List<EventBase>();
    public Guid Id { get; private set; } = Guid.NewGuid();

    [NotMapped] public IReadOnlyCollection<EventBase> DomainEvents => _domainEvents.AsReadOnly();

    public void AddDomainEvent(EventBase domainEvent)
    {
        _domainEvents.Add(domainEvent);
    }

    public void RemoveDomainEvent(EventBase domainEvent)
    {
        _domainEvents.Remove(domainEvent);
    }

    public void ClearDomainEvents()
    {
        _domainEvents.Clear();
    }
}