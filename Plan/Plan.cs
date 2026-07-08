using System;
using System.Collections.Generic;
using System.Numerics;
using System.Text;

namespace PlanCore
{
    public class Plan: List<Task>
    {
        public Plan() { }

        public Plan(string fileName)
        {
            ReadTasksFromFile(fileName);
        }

        private void ReadTasksFromFile(string fileName)
        {
            string planText = File.ReadAllText(fileName);

            if(planText.Length == 0)
            {
                return;
            }

            foreach (var taskText in planText.Split('\n'))
            {
                if (string.IsNullOrEmpty(taskText))
                {
                    continue;
                }
                var task = new Task
                {
                    Name = taskText
                };
                Add(task);
            }
        }

        public void print()
        {
            for (int i = 0; i < Count; i++)
            {
                Console.WriteLine($"[{i + 1}]\t{this[i].Name}");
            }
        }

        public string toString()
        {
            StringBuilder stringBuilder = new StringBuilder();

            foreach (var task in this)
            {
                stringBuilder.Append(task.Name);
                stringBuilder.AppendLine();
            }

            return stringBuilder.ToString();
        }
        
        public void createTask()
        {
            Console.Write("Enter task name: ");
            string? taskName = Console.ReadLine();
            if (!string.IsNullOrEmpty(taskName))
            {
                Add(new Task { Name = taskName });
                Console.WriteLine($"Task \"{taskName}\" added.");
            }
            else
            {
                Console.WriteLine("Task name cannot be empty.");
            }
        }

        public void deleteTask()
        {
            Console.Write("Enter the number of the task to be deleted:");
            int number;
            bool success = int.TryParse(Console.ReadLine(), out number);
            if (!success)
            {
                Console.WriteLine("Failed to parse the number.");
            }
            else if (number < 1 || number > Count)
            {
                Console.WriteLine("The number is out of range.");
            }
            else
            {
                RemoveAt(number - 1);
            }
        }
    }
}
