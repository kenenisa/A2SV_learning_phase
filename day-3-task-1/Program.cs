using System;

public class Program
{
    public static string ReadLine(string ask, Func<string, bool> condition)
    {
        Console.Write(ask);
        string read = Console.ReadLine();
        while (condition(read))
        {
            Console.WriteLine("Please enter a valid input");
            Console.Write(ask);
            read = Console.ReadLine();
        }
        return read;
    }
    public static int ReadNumber(string prompt)
    {
        int result = 0;
        ReadLine(prompt, (read) =>
                {
                    return !int.TryParse(read, out result) || result < 0;
                });
        return result;
    }
    public static void Main()
    {
        Task task1 = new Task
        {
            Name = "Wash dishes",
            Description = "You need to wash the dishes",
            Category = TaskCategories.Personal,
            IsCompleted = false
        };

        TaskManager taskManager = new();

        int choice = -1;
        while (choice != 0)
        {
            Console.WriteLine("+++++++");
            Console.WriteLine("Menu: Add");
            Console.WriteLine("    1. Add Task");
            Console.WriteLine("View");
            Console.WriteLine("    2. All tasks");
            int x = 3;
            foreach (TaskCategories task in Enum.GetValues(typeof(TaskCategories)))
            {
                Console.WriteLine(String.Format("    {0}. {1} tasks", x, task));
                x++;
            }
            Console.WriteLine("0. Exit");

            choice = ReadNumber("Choice: ");
            Console.WriteLine("+++++++");

            if (choice == 1)
            {
                int y = 1;
                foreach (TaskCategories t in Enum.GetValues(typeof(TaskCategories)))
                {
                    Console.WriteLine(String.Format("{0}. select {1}", y, t));
                    y++;
                }
                TaskCategories cat = (TaskCategories)ReadNumber("Select a task category: ");
                Task task = new Task
                {
                    Name = ReadLine("Name: ", (read) => read.Equals("")),
                    Description = ReadLine("Description: ", (read) => read.Equals("")),
                    Category = cat,
                    IsCompleted = ReadNumber("1 for completed, 2 for incomplete: ") == 1
                };
                taskManager.AddTask(task);
            }
            else if (choice == 2)
            {
                taskManager.DisplayTasks((task) => { return true; });
            }
            else if (choice > 2 && choice < Enum.GetNames(typeof(TaskCategories)).Length)
            {
                taskManager.DisplayTasks((task) => { return task.Category == (TaskCategories)choice; });
            }
            else if (choice == 0)
            {
                Console.WriteLine("Good Bye");
            }
            else
            {
                Console.WriteLine("Invalid Input");
            }
        }

    }
}
