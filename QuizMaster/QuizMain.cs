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
        internal static void QuizMain()
        {
            List<QuizQuestion> quizQuestions = Helpers.GetQuestions();
            Dictionary<string, string> quizAnswers = new Dictionary<string, string>();

            foreach (QuizQuestion q in quizQuestions)
            {
                Console.WriteLine(q.Question);
                int optionCntr = 0;
                foreach (string option in q.Options)
                {
                    Console.WriteLine($"{Helpers.GetOptionPrefix(optionCntr)}. {option}");
                    quizAnswers.Add(Helpers.GetOptionPrefix(optionCntr), option);
                    optionCntr++;
                }

                string response = "";

                bool isValidResponse = false;
                while (!isValidResponse) // If the response is invalid, ask again.
                {
                    Console.WriteLine("Enter your answer:\n");
                    response = Console.ReadLine();
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
                    Console.WriteLine("Correct!");
                }
                else
                {
                    Console.WriteLine($"Incorrect! The correct answer is: {q.Answer}");

                }
            }
        }
    }
}
