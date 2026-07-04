using PlanCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace PlanManager
{
    public class PlanManager
    {
        PlanCore.Plan plan;

        public PlanManager(string dataFilePath)
        {
            plan = new PlanCore.Plan(dataFilePath);
        }

        private char? readOperation()
        {
            Console.Write("Choose to (p)rint, (c)reate or (q)uit: ");

            char? operation = null;
            string? input = Console.ReadLine();
            if (!string.IsNullOrEmpty(input))
            {
                operation = input[0];
            }
            return operation;
        }

        public void startInteraction()
        {
            char? operation;

            bool exited = false;

            do
            {
                operation = readOperation();

                switch (operation)
                {
                    case 'p':
                        plan.print();
                        break;
                    case 'c':
                        Console.Write("Enter task name: ");
                        string? taskName = Console.ReadLine();
                        if (!string.IsNullOrEmpty(taskName))
                        {
                            plan.Add(new PlanCore.Task { Name = taskName });
                            Console.WriteLine($"Task \"{taskName}\" added.");
                        }
                        else
                        {
                            Console.WriteLine("Task name cannot be empty.");
                        }
                        break;
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

    }
}
