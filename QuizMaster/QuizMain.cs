using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using QuizMaster.QuizCore;
using QuizMaster.Structs;
using QuizMaster.Utils;

namespace QuizMaster
{
    internal class Quiz
    {
        public static int CorrectAnswers = 0;
        public static int IncorrectAnswers = 0;
        public static int TotalQuestions = 0;

        internal static void QuizMain()
        {
            List<QuizQuestion> quizQuestions = new List<QuizQuestion>();

            // Get and store the questions in a local variable.
            // If there is an error when loading the JSON, display an error, and return to the main menu.
            try
            {
                quizQuestions = Helpers.GetQuestions();
            }
            catch (Exception ex)
            {
                Logging.LogError($"Error loading quiz questions: {ex.Message}");
                Console.Clear();
                Console.WriteLine("Failed to load quiz data from JSON.");
                Console.WriteLine("Please make sure the JSON file exists and is correctly formatted.");
                Console.WriteLine("Press any key to return to the main menu...");
                Console.ReadKey();
                Helpers.ReturnToMenu(true);
            }

            TotalQuestions = quizQuestions.Count;

            Logging.LogMessage($"Starting quiz with {TotalQuestions} questions.");

            foreach (QuizQuestion q in quizQuestions)
            {
                Dictionary<string, string> quizAnswers = new Dictionary<string, string>();
                Logging.LogMessage($"Question: {q.Question}");
                Console.WriteLine($"Question {quizQuestions.IndexOf(q) + 1}/{quizQuestions.Count}:");
                Console.WriteLine(q.Question);
                Console.WriteLine("----");
                // Display options and add them to a dictionary for answer checking.
                int optionCntr = 0;
                foreach (string option in q.Options)
                {
                    Console.WriteLine($"{Helpers.GetOptionPrefix(optionCntr)}. {option}");
                    quizAnswers.Add(Helpers.GetOptionPrefix(optionCntr), option);
                    optionCntr++;
                }
                Console.WriteLine("----");

                string response = "";

                // If the response is invalid, ask again.
                bool isValidResponse = false;
                while (!isValidResponse)
                {
                    Console.WriteLine("Enter your answer:");
                    // Read the response and convert it to uppercase for compatibility.
                    response = Console.ReadLine().ToUpper();
                    if (!quizAnswers.ContainsKey(response))
                    {
                        Console.WriteLine("Invalid input. Please try again.");
                        Logging.LogError($"Invalid input: {response}");
                    }
                    else
                    {
                        isValidResponse = true;
                    }
                }

                if (quizAnswers[response] == q.Answer)
                {
                    Console.Clear();
                    Console.WriteLine("Correct!");
                    Logging.LogMessage($"Correct answer: {q.Answer}");
                    // Use a line separator instead of clearing the console so the user can see their previous result.
                    Console.WriteLine("----");
                    CorrectAnswers++;
                }
                else
                {
                    Console.Clear();
                    Console.WriteLine($"Incorrect! The correct answer is: {q.Answer}");
                    Logging.LogMessage($"Incorrect answer: {q.Answer}");
                    Console.WriteLine("----");
                    IncorrectAnswers++;
                }
            }

            PostQuizSeq();
        }

        // Show the results of the quiz and return to the main menu.
        internal static void PostQuizSeq()
        {
            Console.WriteLine("Quiz Completed!");
            Console.WriteLine($"Score: {CorrectAnswers}/{TotalQuestions}");
            Console.WriteLine($"Accuracy: {(CorrectAnswers / (double)TotalQuestions) * 100}%");
            Console.WriteLine("Press any key to return to the main menu...");
            Console.ReadKey();
            Helpers.ReturnToMenu(true);
        }
    }
}
