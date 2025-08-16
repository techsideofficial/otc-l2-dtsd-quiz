using System.Diagnostics;
using System;
using QuizMaster.Utils;

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
            Logging.LogMessage("Application started.");
            Console.WriteLine("--QUIZMASTER--");
            Console.WriteLine("1. Start Quiz");
            Console.WriteLine("2. Settings");
            Console.WriteLine("3. Help");
            Console.WriteLine("4. Exit");

            switch (Console.ReadLine())
            {
                case "1":
                    // Start the quiz
                    Logging.LogMessage("Starting quiz...");
                    Console.Clear();
                    Quiz.QuizMain();
                    break;
                case "2":
                    Console.Clear();
                    // Edit Questions
                    QuizSettings.PrintAndListenForOptions();
                    break;
                case "3":
                    Console.Clear();
                    Process.Start(new ProcessStartInfo() { 
                        FileName = "https://techsideofficial.github.io/otc-l2-dtsd-quiz/build/docs/basic-usage", 
                        UseShellExecute = true 
                    });
                    break;
                case "4":
                    // Quit the application
                    Console.Clear();
                    Logging.LogMessage("Quitting...");
                    Environment.Exit(0);
                    break;
                default:
                    Console.WriteLine("Invalid input. Please try again.");
                    Logging.LogError("ConsoleInputError: Invalid input. Please try again.");
                    // Clear the console for better readability.
                    Console.Clear();
                    break;
            }

            PrintAndListenForOptions();
        }
    }
}
