using System;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Todo.Ports.UseCases;

namespace Todo.Adapters.FileSystemTaskStore.DependencyInjection;

public static class TaskStoreExtensions
{
    public static void UseFileSystemStore(this IServiceProvider _, IServiceCollection services, IConfiguration configuration)
    {
        FileSystemTaskStoreConfiguration app = new FileSystemTaskStoreConfiguration();

        configuration.Bind("FileSystemTaskStore", app);

        services.AddSingleton(app);
        services.AddSingleton<StoreContext>();
        services.AddTransient<ITaskStore, TaskStore>();
    }
}
