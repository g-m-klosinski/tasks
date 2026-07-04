using System.Numerics;

namespace MyPlanTests
{
    public class PlanManagerTest
    {
        [Fact]
        public void ShouldExitInteractionOnQuitCommand()
        {
            var manager = new PlanManager.PlanManager(["test-data/empty-plan.txt"]);

            // Simulate user typing 'q' (plus Enter) to quit the interaction.
            var originalIn = Console.In;
            try
            {
                Console.SetIn(new System.IO.StringReader("q" + Environment.NewLine));
                manager.startInteraction();
                // If startInteraction returns without throwing, it exited on the quit command.
            }
            finally
            {
                Console.SetIn(originalIn);
            }
        }

        [Fact]
        public void ShouldPrintTasksOnPrintCommand()
        {
            var manager = new PlanManager.PlanManager(["test-data/single-task.txt"]);
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
}
}
