using System;

namespace CoreServices
{
    public static class Logger
    {
        public static void LogWarn(string WarnMessage, params object[] optionalParams)
        {
            Console.WriteLine(WarnMessage, optionalParams);
        }

        public static void LogError(Exception ex, string ErrorMessage, params object[] optionalParams)
        {
            Console.WriteLine(ErrorMessage, optionalParams);
        }

        public static void LogInfo(string InfoMessage, params object[] optionalParams)
        {
            Console.WriteLine(InfoMessage, optionalParams);
        }
    }
}
