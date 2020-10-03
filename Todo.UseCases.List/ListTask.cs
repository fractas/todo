using System.Collections.Generic;

using MediatR;

using Todo.Ports.Entities;

namespace Todo.UseCases.List
{
    public class ListTask : IRequest<IEnumerable<ITask>>
    {
        public int PageNumber { get; set; }

        public int PageSize { get; set; }
    }
}
