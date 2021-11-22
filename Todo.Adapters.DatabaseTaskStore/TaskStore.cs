using System;
using System.Collections.Generic;
using System.Linq;
using Todo.Entities;
using Todo.Ports.Entities;
using Todo.Ports.UseCases;

namespace Todo.Adapters.DatabaseTaskStore;

public class TaskStore : ITaskStore
{
    private readonly StoreContext _context;

    public TaskStore(StoreContext context)
    {
        _context = context;
    }

    public IEnumerable<ITask> List(Func<ITask, bool> predicate, int pageNumber, int pageSize) =>
        _context.Tasks.Where(predicate).Skip(pageSize * --pageNumber).Take(pageSize);

    public bool TryFind(Guid id, out ITask task)
    {
        try
        {
            task = _context.Tasks.First(t => t.Id == id);

            return true;
        }
        catch
        {
            task = Task.Empty;

            return false;
        }
    }

    public void Save(ITask task)
    {
        Remove(task.Id);

        _context.Tasks.Add(task);

        _context.SaveChanges();
    }

    public void Remove(Guid id)
    {
        if (TryFind(id, out ITask found))
        {
            _context.Remove(found);
        }
    }

    public long Count() =>
        _context.Tasks.Count();
}
