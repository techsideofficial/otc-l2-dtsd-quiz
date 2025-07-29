using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using QuizMaster.Structs;
using QuizMaster.Utils;

namespace QuizMaster.QuizCore
{
    internal class Helpers
    {
        internal static List<QuizQuestion> GetQuestions()
        {
            if (!File.Exists(Globals.QuestionsFilePath))
            {
                File.WriteAllText(Globals.QuestionsFilePath, JsonConvert.SerializeObject(new List<QuizQuestion>()));
            }

            return JsonConvert.DeserializeObject<List<QuizQuestion>>(File.ReadAllText(Globals.QuestionsFilePath)) ?? new List<QuizQuestion>();
        }

        internal static void WriteQuestion(QuizQuestion question)
        {
            List<QuizQuestion> questions = GetQuestions();
            questions.Add(question);
            File.WriteAllText(Globals.QuestionsFilePath, JsonConvert.SerializeObject(questions, Formatting.Indented));
        }

        // If the option number is more than 26, use two letters instead.
        internal static string GetOptionPrefix(int optionNumber)
        {
            char[] lettersLower = "abcdefghijklmnopqrstuvwxyz".ToCharArray();
            char[] lettersUpper = "ABCDEFGHIJKLMNOPQRSTUVWXYZ".ToCharArray();
            char[] numbers = "0123456789".ToCharArray();

            string qOptionPrefix;
            if (optionNumber < 26)
            {
                qOptionPrefix = lettersUpper[optionNumber].ToString();
            }
            else
            {
                int letterIndex = optionNumber / 26;
                int numberIndex = optionNumber % 26;

                qOptionPrefix = lettersUpper[letterIndex].ToString() + lettersUpper[letterIndex].ToString();
            }

            return qOptionPrefix;
        }

        internal static void ReturnToMenu(bool clearConsole)
        {
            if (clearConsole)
            {
                Console.Clear();
            }

            Logging.LogMessage("Returning to menu.");
            Program.PrintAndListenForOptions();
        }
    }
}
