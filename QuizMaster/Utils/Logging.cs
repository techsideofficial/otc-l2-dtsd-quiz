namespace QuizMaster.Utils
{
    public partial class Logging
    {
        public static void LogMessage(string message)
        {
            string tempMsg = String.Concat("[Log] ", message); // Attach a prefix, so it becomes "[Log] message" for easier readability.
            File.AppendAllText(
                Path.Combine(Globals.ApplicationPath, "QuizMaster.log"), // Write the log file in the current directory.
                tempMsg + "\n"
            );
        }

        public static void LogWarn(string message)
        {
            string tempMsg = String.Concat("[Warn] ", message);
            File.AppendAllText(
                Path.Combine(Globals.ApplicationPath, "QuizMaster.log"),
                tempMsg + "\n"
            );
        }

        public static void LogError(string message)
        {
            string tempMsg = String.Concat("[Error] ", message);
            File.AppendAllText(
                Path.Combine(Globals.ApplicationPath, "QuizMaster.log"),
                tempMsg + "\n"
            );
        }
    }
}
