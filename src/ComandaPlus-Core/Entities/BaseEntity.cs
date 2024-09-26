using ComandaPlus_Core.Validation.Exceptions;

namespace ComandaPlus_Core.Entities;

public abstract class BaseEntity
{
    public Guid Id { get; protected set; }
}
