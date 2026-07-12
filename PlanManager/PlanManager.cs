using PlanCore;
using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json;

namespace PlanManager
{
    public class PlanManager
    {
        string? dataFilePath;
        public PlanCore.Plan plan;

        public PlanManager() {
            plan = new PlanCore.Plan();
        }
        
        public PlanManager(string dataFilePath)
        {
            try
            {
                string json = File.ReadAllText(dataFilePath);

                plan = JsonSerializer.Deserialize<PlanCore.Plan>(json);
                this.dataFilePath = dataFilePath;
            }
            catch
            {
                Console.WriteLine($"Failed to parse {dataFilePath}");
                Environment.Exit(1);
            }
        }

        private char? readOperation()
        {
            Console.Write("(p)rint, (a)dd, (c)omplete, (d)elete or (q)uit: ");

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
                    case 'a':
                        plan.addTask();
                        break;
                    case 'd':
                        plan.deleteTask();
                        break;
                    case 'c':
                        plan.completeTask();
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

            if (!string.IsNullOrEmpty(dataFilePath))
            {
                //File.WriteAllText(dataFilePath, plan.toString());
                plan.dump(dataFilePath);
            }
        }

    }
}
