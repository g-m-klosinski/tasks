using System;
using System.Collections.Generic;
using System.Numerics;
using System.Text;
using System.Text.Json;

namespace PlanCore
{
    public class Plan: List<Task>
    {

        public void print()
        {
            for (int i = 0; i < Count; i++)
            {
                Console.WriteLine($"[{i + 1, 2}] {(this[i].IsCompleted ? "X" : " ")} {this[i].Name}");
            }
        }

        public void addTask()
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
            Console.Write("Enter the number of the task to be deleted: ");
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

        public void completeTask()
        {
            Console.Write("Enter the number of the task to be completed: ");
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
                this[number - 1].IsCompleted = true;
            }
        }

        public void dump(string dataFilePath)
        {
            string json = JsonSerializer.Serialize(this);
            File.WriteAllText(dataFilePath, json);
        }
    }
}
