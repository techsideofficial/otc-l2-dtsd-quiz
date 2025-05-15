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
            List<QuizQuestion> quizQuestions = Helpers.GetQuestions();
            TotalQuestions = quizQuestions.Count;

            foreach (QuizQuestion q in quizQuestions)
            {
                Dictionary<string, string> quizAnswers = new Dictionary<string, string>();
                Console.WriteLine(q.Question);
                int optionCntr = 0;
                foreach (string option in q.Options) // Display options and add them to a dictionary for answer checking.
                {
                    Console.WriteLine($"{Helpers.GetOptionPrefix(optionCntr)}. {option}");
                    quizAnswers.Add(Helpers.GetOptionPrefix(optionCntr), option);
                    optionCntr++;
                }

                string response = "";

                bool isValidResponse = false;
                while (!isValidResponse) // If the response is invalid, ask again.
                {
                    Console.WriteLine("Enter your answer:");
                    response = Console.ReadLine().ToUpper(); // Read the response and convert it to uppercase.
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

        internal static void PostQuizSeq()
        {
            Console.WriteLine("Quiz Completed!");
            Console.WriteLine($"Score: {CorrectAnswers}/{TotalQuestions}");
            Console.WriteLine($"Accuracy: {(CorrectAnswers / (double)TotalQuestions) * 100}%");
            Console.WriteLine("Press any key to return to the main menu...");
            Console.ReadKey();
            Console.Clear();
            Program.PrintAndListenForOptions(); // Return to the main menu.
        }
    }
}
