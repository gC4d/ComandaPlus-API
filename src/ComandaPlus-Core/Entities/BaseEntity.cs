using System;

namespace ComandaPlus_Core.Entities;

public abstract class BaseEntity
{
    public Guid Id { get; protected set; }
}
