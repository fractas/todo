using System;
using System.Collections.Generic;
using System.Threading.Tasks;

using Todo.Entities;

namespace Todo.Ports.UseCases
{
    public interface ITaskService
    {
        Task<Guid> Add(string description);

        void Do(Guid taskId);

        Task<IEnumerable<ITask>> List(int pageNumber = 1, int pageSize = 10);

        void Remove(Guid taskId);

        void Undo(Guid taskId);
    }
}
