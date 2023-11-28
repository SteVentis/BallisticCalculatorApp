namespace Modules.Users.Domain.Abstractions;

public abstract class Entity
{
    private readonly List<IDomainEvent> _doaminEvents = new();
    protected Entity(Guid id) 
    {
        Id = id;
    }

    public Guid Id { get; init; }
    public List<IDomainEvent> DomainEvents => _doaminEvents.ToList();

    protected void Raise(IDomainEvent domainEvent)
    {
        _doaminEvents.Add(domainEvent);
    }
}
