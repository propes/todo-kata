using System.Collections.Generic;

namespace ApiIntegrationKata
{
    public interface ITodoItemCommandHandler
    {
        void Handle(AddTodoItem command);
    }

    public class AddTodoItem
    {
        public NewTodoItemDto TodoItem { get; set; }
    }
    
    public class TodoItemCommandHandler : ITodoItemCommandHandler
    {
        private readonly IList<TodoItem> _todoItems;

        public TodoItemCommandHandler(IList<TodoItem> todoItems)
        {
            _todoItems = todoItems;
        }
        
        public void Handle(AddTodoItem command)
        {
            var dto = command.TodoItem;
            var todoItem = new TodoItem(dto.Description, dto.Priority);
            
            _todoItems.Add(todoItem);
        }
    }
}