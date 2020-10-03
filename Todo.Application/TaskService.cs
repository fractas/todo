using System;
using System.Collections.Generic;
using System.Threading.Tasks;

using MediatR;

using Todo.Ports.Entities;
using Todo.Ports.UseCases;
using Todo.UseCases.Add;
using Todo.UseCases.Do;
using Todo.UseCases.List;
using Todo.UseCases.Remove;
using Todo.UseCases.Undo;

namespace Todo.Application
{
    public class TaskService : ITaskService
    {
        private readonly IMediator _mediator;

        public TaskService(IMediator mediator)
        {
            _mediator = mediator;
        }

        public async Task<IEnumerable<ITask>> List(int pageNumber = 1, int pageSize = 10) =>
            await _mediator.Send(new ListTask { PageNumber = pageNumber, PageSize = pageSize });

        public async Task<Guid> Add(string description) =>
            await _mediator.Send(new AddTask { Description = description });

        public async void Remove(Guid taskId) =>
            await _mediator.Send(new RemoveTask { TaskId = taskId });

        public async void Do(Guid taskId) =>
            await _mediator.Send(new DoTask { TaskId = taskId });

        public async void Undo(Guid taskId) =>
            await _mediator.Send(new UndoTask { TaskId = taskId });
    }
}
