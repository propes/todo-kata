namespace ApiIntegrationKata
{
    public class TodoItem
    {
        public string Description { get; }
        public int Priority { get; }
        public bool IsCompleted { get; }

        public TodoItem(string description, int priority)
        {
            Description = description;
            Priority = priority;
            IsCompleted = false;
        }
    }
}