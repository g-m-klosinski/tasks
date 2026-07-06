using System.Numerics;

namespace MyPlanTests
{
    public class CRUDTest
    {
        [Fact]
        public void ShouldPrintTasksOnPrintCommand()
        {
            var manager = new PlanManager.PlanManager();

            manager.plan.Add(new PlanCore.Task { Name = "Do the washing"});
            // Simulate user typing 'p' (plus Enter) to print tasks.
            var originalIn = Console.In;
            var originalOut = Console.Out;
            try
            {
                using (var sw = new System.IO.StringWriter())
                {
                    Console.SetIn(new System.IO.StringReader("p" + Environment.NewLine + "q" + Environment.NewLine));
                    Console.SetOut(sw);
                    manager.startInteraction();
                    var output = sw.ToString();
                    Assert.Contains("[1]", output);
                    Assert.DoesNotContain("[2]", output); // Ensure only one task is printed
                }
            }
            finally
            {
                Console.SetIn(originalIn);
                Console.SetOut(originalOut);
            }
        }

        [Fact]
        public void ShouldAddTaskOnCreateCommand()
        {
            var manager = new PlanManager.PlanManager();
            // Simulate user typing 'c' (plus Enter) to create a task, then 'q' to quit.
            var originalIn = Console.In;
            var originalOut = Console.Out;
            try
            {
                using (var sw = new System.IO.StringWriter())
                {
                    Console.SetIn(new System.IO.StringReader("c" + Environment.NewLine + "New Task" + Environment.NewLine + "p" + Environment.NewLine + "q" + Environment.NewLine));
                    Console.SetOut(sw);
                    manager.startInteraction();
                    var output = sw.ToString();
                    Assert.Contains("New Task", output); // Ensure the new task is printed
                }
            }
            finally
            {
                Console.SetIn(originalIn);
                Console.SetOut(originalOut);
            }
        }
    }
}
