using TaskManagerAPI.Models;

namespace TaskManagerAPI.Services
{
    public class TaskService
    {
        private readonly List<TaskItem> _tasks = new();
        private int _nextId = 1;

        public IEnumerable<TaskItem> GetAll() => _tasks;

        public TaskItem Add(string description)
        {
            var item = new TaskItem { Id = _nextId++, Description = description };
            _tasks.Add(item);
            return item;
        }

        public TaskItem? Toggle(int id)
        {
            var task = _tasks.FirstOrDefault(t => t.Id == id);
            if (task != null) task.IsCompleted = !task.IsCompleted;
            return task;
        }

        public bool Delete(int id)
        {
            var task = _tasks.FirstOrDefault(t => t.Id == id);
            return task != null && _tasks.Remove(task);
        }
    }
}
