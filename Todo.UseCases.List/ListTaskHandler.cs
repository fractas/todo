using System.Collections.Generic;

using MediatR;

using Todo.Entities;
using Todo.Ports.UseCases;

namespace Todo.UseCases.List
{
    public class ListTaskHandler : RequestHandler<ListTask, IEnumerable<ITask>>
    {
        private readonly ITaskStore _store;

        public ListTaskHandler(ITaskStore store)
        {
            _store = store;
        }

        protected override IEnumerable<ITask> Handle(ListTask request)
        {
            return _store.List(t => true, request.PageNumber, request.PageSize);
        }
    }
}
