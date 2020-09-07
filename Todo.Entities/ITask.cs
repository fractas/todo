using System;

namespace Todo.Entities
{
    public interface ITask : IAggregate, IEquatable<ITask>, IComparable<ITask>
    {
        string Description { get; }

        bool Done { get; }

        void Do();

        void Undo();
    }
}
