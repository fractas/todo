
using System;

using MediatR;

namespace Todo.UseCases.Do
{
    public class DoTask : IRequest
    {
        public Guid TaskId { get; set; }
    }
}
