namespace PlanManager
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            if (args.Length != 1)
            {
                Console.WriteLine("Usage: PlanManager [dataFilePath]");
                return;
            }
            new PlanManager(args[0]).startInteraction();
        }
    }
}