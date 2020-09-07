using MediatR;

using Todo.Entities;
using Todo.Ports.UseCases;

namespace Todo.UseCases.Do
{
    public class DoTaskHandler : RequestHandler<DoTask>
    {
        private readonly ITaskStore _store;

        public DoTaskHandler(ITaskStore store)
        {
            _store = store;
        }

        protected override void Handle(DoTask request)
        {
            if (_store.TryFind(request.TaskId, out ITask task))
            {
                task.Do();

                _store.Save(task);
            }
        }
    }
}
