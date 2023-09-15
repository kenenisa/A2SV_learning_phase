class TaskManager
{
    public List<Task> tasks = new();
    string filePath = "tasks.txt";
    public TaskManager()
    {
        Read();
    }
    public async void Write()
    {
        try
        {

            foreach (Task task in tasks)
            {
                await File.AppendAllTextAsync(filePath, task.ToString() + "\n");
            }
        }
        catch (Exception error)
        {
            Console.WriteLine(error.Message);
        }
    }
    public async void Read()
    {
        try
        {

            string text = await File.ReadAllTextAsync(filePath);
            string[] lines = text.Split(new[] { Environment.NewLine }, StringSplitOptions.None);
            foreach (string line in lines)
            {

                string[] taskLine = line.Split(new string[] { "-" }, StringSplitOptions.None);
                if (taskLine.Length == 4)
                {

                    TaskCategories cat = (TaskCategories)Enum.Parse(typeof(TaskCategories), taskLine[2], true);

                    tasks.Add(new Task
                    {
                        Name = taskLine[0],
                        Description = taskLine[1],
                        Category = cat,
                        IsCompleted = taskLine[3] == "true"
                    });
                }
            }
        }
        catch (Exception error)
        {
            Console.WriteLine(error.Message);
        }
    }
    public void AddTask(Task task)
    {
        tasks.Add(task);
        Write();
    }
    public void DisplayTasks(Func<Task, bool> filterFunction)
    {
        if (tasks.Count == 0)
        {
            Console.WriteLine("There are no tasks yet");
        }
        Console.WriteLine("");
        Console.WriteLine("Tasks");
        foreach (Task task in tasks.Where(filterFunction).ToList())
        {
            Console.WriteLine("Name: " + task.Name);
            Console.WriteLine("Description: " + task.Description);
            Console.WriteLine("Category: " + task.Category);
            Console.WriteLine("IsCompleted: " + task.IsCompleted);
            Console.WriteLine("------");
        }
    }
}