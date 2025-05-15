namespace QuizMaster
{
    internal class Program
    {
        static void Main(string[] args)
        {
            PrintAndListenForOptions();
        }

        internal static void PrintAndListenForOptions()
        {
            Console.WriteLine("--QUIZMASTER--");
            Console.WriteLine("1. Start Quiz");
            Console.WriteLine("2. Quit Application");

            switch (Console.ReadLine())
            {
                case "1":
                    // Start the quiz
                    Quiz.QuizMain();
                    break;
                case "2":
                    // Quit the application
                    Environment.Exit(0);
                    break;
                default:
                    Console.WriteLine("Invalid input. Please try again.");
                    // Clear the console for better readability.
                    Console.Clear();
                    PrintAndListenForOptions();
                    break;
            }
        }
    }
}
