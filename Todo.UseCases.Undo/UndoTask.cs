using System;

using MediatR;

namespace Todo.UseCases.Undo
{
    public class UndoTask : IRequest
    {
        public Guid TaskId { get; set; }
    }
}
