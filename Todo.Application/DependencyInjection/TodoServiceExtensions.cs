using System;
using MediatR;
using Microsoft.Extensions.DependencyInjection;
using Todo.Ports.UseCases;
using Todo.UseCases.Add;
using Todo.UseCases.Do;
using Todo.UseCases.List;
using Todo.UseCases.Remove;
using Todo.UseCases.Undo;

namespace Todo.Application.DependencyInjection;

public static class TodoServiceExtensions
{
    public static IServiceCollection AddTodoService(this IServiceCollection services, Action<IServiceProvider> provider)
    {
        provider.Invoke(null);

        services.AddMediatR(new Type[]
        {
            typeof(AddTask),
            typeof(RemoveTask),
            typeof(ListTask),
            typeof(DoTask),
            typeof(UndoTask)
        });

        services.AddScoped<ITaskService, TaskService>();

        return services;
    }
}
