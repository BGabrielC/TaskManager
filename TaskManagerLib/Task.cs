using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaskManagerLib
{
    public class Task
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public DateTime DueDate { get; set; }
        public bool Completed { get; set; }
 
        public Task(string name, string description, DateTime dueDate)
        {
            Name = name;
            Description = description;
            DueDate = dueDate;
            Completed = false;
        }

        public override string ToString()
        {
            return string.Format("{0} - {1} - {2} - {3}", Name, Description, DueDate, Completed);
        }


        public static Task ParseFromFile(string line)
        {
            string[] parts = line.Split('|');
            string name = parts[0];
            string description = parts[1];
            DateTime dueDate = DateTime.Parse(parts[2]);
            bool completed = bool.Parse(parts[3]);
            return new Task(name, description, dueDate) { Completed = completed };
        }

        public static void SaveToFile(string fileName, Task task)
        {
            string line = string.Format("{0}|{1}|{2}|{3}", task.Name, task.Description, task.DueDate, task.Completed);
            System.IO.File.AppendAllText(fileName, line + Environment.NewLine);
        }

       
        public static List<Task> ReadFromFile(string fileName)
        {
            string directory = @"../../Tasks";
            string path = Path.Combine(directory, fileName);
            List<Task> tasks = new List<Task>();
            string[] lines = System.IO.File.ReadAllLines(path);
            foreach (string line in lines)
            {
                tasks.Add(ParseFromFile(line));
            }
            return tasks;
        }

        public static Task ParseFromConsole()
        {
            Console.Write("Name: ");
            string name = Console.ReadLine();
            Console.Write("Description: ");
            string description = Console.ReadLine();
            Console.Write("Due Date: ");
            DateTime dueDate = DateTime.Parse(Console.ReadLine());
            return new Task(name, description, dueDate);
        }

    }
}
