namespace Template.Domain.Shared.Exceptions;

public class EntityNotFoundException : 
    Exception
{
    public EntityNotFoundException(Type entityType, int id) :
        base($"Cant found desired entity of type {nameof(entityType)} and identification {id}.")
    { }

    public EntityNotFoundException(Type entityType) :
        base($"Cant found desired entity of type {nameof(entityType)}.")
    { }
}
