namespace QuizMaster
{
    public class Globals
    {
        // Here, we define the application's global variables.
        public readonly static string ApplicationPath = AppDomain.CurrentDomain.BaseDirectory;

        public readonly static string LogFilePath = Path.Combine(ApplicationPath, "QuizMaster.log");

        public readonly static string QuestionsFilePath = Path.Combine(ApplicationPath, "QuizConfig_Questions.json");
    }
}