using System;
using Microsoft.Extensions.DependencyInjection;
using Todo.Ports.UseCases;

namespace Todo.Adapters.DatabaseTaskStore.DependencyInjection;

public static class TaskStoreExtensions
{
    public static void UseDatabaseStore(this IServiceProvider _, IServiceCollection services)
    {
        services.AddDbContext<StoreContext>();
        services.AddTransient<ITaskStore, TaskStore>();
    }
}
