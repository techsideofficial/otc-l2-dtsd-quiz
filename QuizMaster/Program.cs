namespace QuizMaster
{
    internal class Program
    {
        static void Main(string[] args)
        {
            PrintAndListenForOptions();
        }

        private static void PrintAndListenForOptions()
        {
            Console.WriteLine("--QUIZMASTER--");
            Console.WriteLine("1. Start Quiz");
            Console.WriteLine("2. Quit Application");
            Console.WriteLine("3. View all question data (DEBUG).");

            switch (Console.ReadLine())
            {
                case "1":
                // Start the quiz
                case "2":
                    // Quit the application
                    Environment.Exit(0);
                    break;
                default:
                    Console.WriteLine("Invalid input. Please try again.");
                    Console.Clear(); // Clear the console for better readability.
                    PrintAndListenForOptions();
                    break;
            }
        }
    }
}
