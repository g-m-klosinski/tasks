using System;
using System.Collections.Generic;
using System.Text;

namespace PlanCore
{
    public class Plan: List<Task>
    {

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
                var task = new Task
                {
                    Name = taskText
                };
                Add(task);
            }
        }

        public void startInteraction()
        {
            char? operation;

            bool exited = false;

            do
            {
                printTasks();
                
                operation = readOperation();

                switch (operation)
                {
                    case 'q':
                        exited = true;
                        break;
                    default:
                        Console.WriteLine($"Invalid operation \"{operation}\"");
                        break;
                }
            }
            while (!exited);
        }

        private void printTasks()
        {
            for (int i = 0; i < Count; i++)
            {
                Console.WriteLine($"{i + 1}. {this[i].Name}");
            }
        }

        private char? readOperation()
        {
            Console.Write("(q)uit? ");

            char? operation = null;
            string? input = Console.ReadLine();
            if (!string.IsNullOrEmpty(input))
            {
                operation = input[0];
            }
            return operation;
        }
    }
}
