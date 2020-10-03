using System;

namespace Todo.Ports.Entities
{
    public interface IEntity
    {
        Guid Id { get; }
    }
}
