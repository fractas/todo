using System;
using System.Collections.Generic;

using Todo.Entities;

namespace Todo.Ports.UseCases
{
    public interface ITaskStore
    {
        IEnumerable<ITask> List(Func<ITask, bool> predicate, int pageNumber, int pageSize);

        bool TryFind(Guid id, out ITask task);

        void Save(ITask task);

        void Remove(Guid id);

        long Count();
    }
}
