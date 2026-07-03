using System.Numerics;

namespace MyPlanTests
{
    public class PlanTest
    {
        [Fact]
        public void ShouldExitInteractionOnQuitCommand()
        {
            var plan = new PlanCore.Plan("test_plan.txt");

            // Simulate user typing 'q' (plus Enter) to quit the interaction.
            var originalIn = Console.In;
            try
            {
                Console.SetIn(new System.IO.StringReader("q" + Environment.NewLine));
                plan.startInteraction();
                // If startInteraction returns without throwing, it exited on the quit command.
            }
            finally
            {
                Console.SetIn(originalIn);
            }
        }
    }
}
