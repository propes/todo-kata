using System.Collections.Generic;
using Microsoft.Extensions.DependencyInjection;

namespace ApiIntegrationKata
{
    public static class DependencyInjectionExtension
    {
        public static IServiceCollection AddDomainServices(this IServiceCollection services)
        {
            var todoItems = new List<TodoItem>();
            services.AddSingleton<ITodoItemCommandHandler>(_ => new TodoItemCommandHandler(todoItems));
            services.AddSingleton<ITodoItemQueryHandler>(_ => new TodoItemQueryHandler(todoItems));
            
            return services;
        }
    }
}