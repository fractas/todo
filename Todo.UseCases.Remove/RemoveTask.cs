using System;

using MediatR;

namespace Todo.UseCases.Remove
{
    public class RemoveTask : IRequest
    {
        public Guid TaskId { get; set; }
    }
}
