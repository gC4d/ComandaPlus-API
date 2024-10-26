using ComandaPlus_API.Validation.Exceptions;

namespace ComandaPlus_API.Entities;

public abstract class BaseEntity
{
    public Guid Id { get; protected set; }
}
