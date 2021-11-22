using MediatR;
using Todo.Ports.Entities;
using Todo.Ports.UseCases;

namespace Todo.UseCases.Undo;

public class UndoTaskHandler : RequestHandler<UndoTask>
{
    private readonly ITaskStore _store;

    public UndoTaskHandler(ITaskStore store)
    {
        _store = store;
    }

    protected override void Handle(UndoTask request)
    {
        if (_store.TryFind(request.TaskId, out ITask task))
        {
            task.Undo();

            _store.Save(task);
        }
    }
}
