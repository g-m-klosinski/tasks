using System.Numerics;

namespace MyPlanTests
{
    public class PlanManagerTest
    {
        [Fact]
        public void ShouldExitInteractionOnQuitCommand()
        {
            var manager = new PlanManager.PlanManager(["empty-plan.txt"]);

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
    }
}
