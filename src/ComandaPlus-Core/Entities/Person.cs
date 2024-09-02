using System;

namespace ComandaPlus_Core.Entities;

public abstract class Person : BaseEntity
{
    public string? Name { get; protected set; }
}
