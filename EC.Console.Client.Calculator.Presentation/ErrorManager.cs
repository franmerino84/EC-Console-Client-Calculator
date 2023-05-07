namespace EC.Console.Client.Calculator.Presentation
{
    public static class ErrorManager
    {
        public static void LaunchError(int errorNumber, string message)
        {
            System.Console.Error.WriteLine($"ERROR CC{errorNumber.ToString("000")}: {message}");
            Environment.Exit(errorNumber);
        }

        public static T LaunchError<T>(int errorNumber, string message)
        {
            LaunchError(errorNumber, message);
            return default(T);
        }
    }
}
