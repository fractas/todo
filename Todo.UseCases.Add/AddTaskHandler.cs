using System;

using MediatR;

using Todo.Entities;
using Todo.Ports.Entities;
using Todo.Ports.UseCases;

namespace Todo.UseCases.Add
{
    public class AddTaskHandler : RequestHandler<AddTask, Guid>
    {
        private readonly ITaskStore _store;

        public AddTaskHandler(ITaskStore store)
        {
            _store = store;
        }

        protected override Guid Handle(AddTask request)
        {
            ITask task = Task.NewTask(request.Description);

            _store.Save(task);

            return task.Id;
        }
    }
}
