using System;

using Todo.Ports.Entities;

namespace Todo.Entities
{
    public struct Task : ITask
    {
        public static readonly ITask Empty = new Task(Guid.Empty, string.Empty, false);

        public static ITask NewTask(string description) =>
            new Task(Guid.NewGuid(), description, false);

        public static ITask Load(Guid id, string description, bool done) =>
            new Task(id, description, done);

        private Task(Guid id, string description, bool done)
        {
            Id = id;

            Description = description;

            Done = done;
        }

        public Guid Id { get; }

        public string Description { get; }

        public bool Done { get; private set; }

        public void Do() =>
            Done = true;

        public void Undo() =>
            Done = false;

        public override string ToString() =>
            $"[{Id}] {Description}";

        public int CompareTo(ITask other) =>
            Description.CompareTo(other.Description);

        public bool Equals(ITask other) =>
            Id.Equals(other.Id);

        public override int GetHashCode() =>
            HashCode.Combine(Id);
    }
}
