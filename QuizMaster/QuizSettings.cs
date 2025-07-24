using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using QuizMaster.QuizCore;
using QuizMaster.Structs;
using QuizMaster.Utils;

namespace QuizMaster
{
    internal class QuizSettings
    {
        internal static void PrintAndListenForOptions()
        {
            Console.WriteLine("1. Return To Menu");
            Console.WriteLine("2. Add Question");

            switch (Console.ReadLine())
            {
                case "1":
                    // Return to menu
                    Console.Clear();
                    Program.PrintAndListenForOptions();
                    break;
                case "2":
                    // Add Question
                    Console.Clear();
                    QuizQuestion newQuestion = new QuizQuestion();
                    Console.WriteLine("Enter the question:\n");
                    newQuestion.Question = Console.ReadLine();
                    bool isAddingOptions = true;
                    while (isAddingOptions)
                    {
                        Console.Clear();
                        Console.WriteLine("Add an option (Type 'done' once you are finished adding answers):\n");
                        string input = Console.ReadLine();
                        if (input == "done")
                        {
                            isAddingOptions = false;
                            Console.Clear();
                            continue;
                        }

                        newQuestion.Options.Add(input);
                    }

                    Dictionary<string, string> quizAnswers = new Dictionary<string, string>();
                    int optionCntr = 0;
                    foreach (string option in newQuestion.Options)
                    {
                        Console.WriteLine($"{Helpers.GetOptionPrefix(optionCntr)}. {option}");
                        quizAnswers.Add(Helpers.GetOptionPrefix(optionCntr), option);
                        optionCntr++;
                    }

                    Console.WriteLine("Enter the correct answer (use the option prefix, e.g. A, B, C):");
                    bool isPickingAnswer = true;
                    while (isPickingAnswer)
                    {
                        string response = Console.ReadLine().ToUpper();
                        if (!quizAnswers.ContainsKey(response))
                        {
                            Console.WriteLine("Invalid input. Please try again.");
                            Logging.LogError("ConsoleInputError: Invalid input. Please try again.");
                            continue;
                        }

                        newQuestion.Answer = quizAnswers[response];
                    }

                    Console.Clear();
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
