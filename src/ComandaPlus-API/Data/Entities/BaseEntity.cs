using ComandaPlus_API.Domain.Exceptions;

namespace ComandaPlus_API.Domain.Entities;

public abstract class BaseEntity
{
    public Guid Id { get; protected set; }
}
