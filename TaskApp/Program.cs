using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskManagerLib;
using Task = TaskManagerLib.Task;

namespace TaskManager
{
    internal class Program
    {
        static void Main(string[] args)
        {

            string filename = "tasks.txt";
            string directory = @"../../Tasks/";
            string path = Path.Combine(directory, filename);
            if (!File.Exists(path))
            {
                File.Create(path).Close();
            }
            List<Task> tasks = Task.ReadFromFile("tasks.txt");
            bool exit = false;
            while (!exit)
            {
                Console.WriteLine("1. View all tasks");
                Console.WriteLine("2. Add a task");
                Console.WriteLine("3. Exit");
                Console.Write("Choose an option: ");
                string option = Console.ReadLine();
                switch (option)
                {
                    case "1":
                        ViewAllTasks(tasks);
                        break;
                    case "2":
                        //AddTask(tasks);
                        break;
                    case "3":
                        exit = true;
                        break;
                    default:
                        Console.WriteLine("Invalid option");
                        break;
                }
            }

            void ViewAllTasks(List<Task> taskList)
            {
                foreach (Task task in taskList)
                {
                    Console.WriteLine(task);
                }
            }

        }
    }
}
