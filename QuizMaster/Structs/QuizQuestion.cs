using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuizMaster.Structs
{
    public class QuizQuestion
    {
        public string? Question { get; set; }
        public string? Answer { get; set; }
        public List<string> Options = new List<string>();
    }
}
