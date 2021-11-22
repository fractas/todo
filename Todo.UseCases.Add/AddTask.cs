using System;
using MediatR;

namespace Todo.UseCases.Add;

public class AddTask : IRequest<Guid>
{
    public string Description { get; set; }
}
