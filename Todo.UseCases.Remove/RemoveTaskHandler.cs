using MediatR;

using Todo.Ports.UseCases;

namespace Todo.UseCases.Remove;

public class RemoveTaskHandler : RequestHandler<RemoveTask>
{
    private readonly ITaskStore _store;

    public RemoveTaskHandler(ITaskStore store)
    {
        _store = store;
    }

    protected override void Handle(RemoveTask request)
    {
        _store.Remove(request.TaskId);
    }
}
