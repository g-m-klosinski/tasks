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

        public void print()
        {
            for (int i = 0; i < Count; i++)
            {
                Console.WriteLine($"{i + 1}. {this[i].Name}");
            }
        }
        
    }
}
