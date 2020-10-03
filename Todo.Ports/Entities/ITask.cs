using System;

namespace Todo.Ports.Entities
{
    public interface ITask : IAggregate, IEquatable<ITask>, IComparable<ITask>
    {
        string Description { get; }

        bool Done { get; }

        void Do();

        void Undo();
    }
}
