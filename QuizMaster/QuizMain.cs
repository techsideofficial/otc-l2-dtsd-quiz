using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using QuizMaster.QuizCore;
using QuizMaster.Structs;

namespace QuizMaster
{
    internal class Quiz
    {
        public static int CorrectAnswers = 0;
        public static int IncorrectAnswers = 0;
        public static int TotalQuestions = 0;

        internal static void QuizMain()
        {
            // Get and store the questions in a local variable.
            List<QuizQuestion> quizQuestions = Helpers.GetQuestions();
            TotalQuestions = quizQuestions.Count;

            foreach (QuizQuestion q in quizQuestions)
            {
                Dictionary<string, string> quizAnswers = new Dictionary<string, string>();
                Console.WriteLine(q.Question);
                // Display options and add them to a dictionary for answer checking.
                int optionCntr = 0;
                foreach (string option in q.Options)
                {
                    Console.WriteLine($"{Helpers.GetOptionPrefix(optionCntr)}. {option}");
                    quizAnswers.Add(Helpers.GetOptionPrefix(optionCntr), option);
                    optionCntr++;
                }

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
                    // Use a line separator instead of clearing the console so the user can see their previous result.
                    Console.WriteLine("----");
                    CorrectAnswers++;
                }
                else
                {
                    Console.Clear();
                    Console.WriteLine($"Incorrect! The correct answer is: {q.Answer}");
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
            Console.Clear();
            // Return to the main menu.
            Program.PrintAndListenForOptions();
        }
    }
}
