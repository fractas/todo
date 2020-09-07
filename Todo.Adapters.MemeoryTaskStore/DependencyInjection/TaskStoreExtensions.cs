using System;

using Microsoft.Extensions.DependencyInjection;

using Todo.Ports.UseCases;

namespace Todo.Adapters.MemoryTaskStore.DependencyInjection
{
    public static class TaskStoreExtensions
    {
        public static void UseMemoryStore(this IServiceProvider _, IServiceCollection services)
        {
            services.AddTransient<StoreContext>();

            services.AddTransient<ITaskStore, TaskStore>();
        }
    }
}
