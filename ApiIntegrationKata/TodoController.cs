using ApiIntegrationKata.Models;
using Microsoft.AspNetCore.Mvc;

namespace ApiIntegrationKata
{
    [Route("api/v1/todo")]
    [ApiController]
    public class TodoController : ControllerBase
    {
        private readonly ITodoItemCommandHandler _commandHandler;
        private readonly ITodoItemQueryHandler _queryHandler;

        public TodoController(
            ITodoItemCommandHandler commandHandler,
            ITodoItemQueryHandler queryHandler)
        {
            _commandHandler = commandHandler;
            _queryHandler = queryHandler;
        }

        [HttpPost]
        public IActionResult PostTodoItem(NewTodoItemDto todoItem)
        {
            _commandHandler.Handle(new AddTodoItem {TodoItem = todoItem});

            return new CreatedResult(string.Empty, todoItem);
        }

        [HttpGet]
        public ActionResult<TodoItemDto> GetTodoItems()
        {
            var todoItems = _queryHandler.Handle(new TodoItemQuery());
            return Ok(todoItems);
        }
    }
}