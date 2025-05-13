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
            return JsonConvert.DeserializeObject<List<QuizQuestion>>(File.ReadAllText(Globals.QuestionsFilePath)) ?? new List<QuizQuestion>();
        }
    }
}
