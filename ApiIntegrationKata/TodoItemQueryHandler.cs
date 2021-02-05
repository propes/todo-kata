using System.Collections.Generic;

namespace ApiIntegrationKata
{
    public class TodoItemQueryHandler : ITodoItemQueryHandler
    {
        private readonly IReadOnlyCollection<TodoItem> _todoItems;

        public TodoItemQueryHandler(IReadOnlyCollection<TodoItem> todoItems)
        {
            _todoItems = todoItems;
        }
        
        public IReadOnlyCollection<TodoItem> Handle(TodoItemQuery query)
        {
            return _todoItems;
        }
    }
    
    
    public interface ITodoItemQueryHandler
    {
        IReadOnlyCollection<TodoItem> Handle(TodoItemQuery query);
    }

    public class TodoItemQuery
    {
    }
}