using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using QuizMaster.Structs;

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
    }
}
