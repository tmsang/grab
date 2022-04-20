using System;
using System.IO;

namespace tmsang.api
{
    public class Utils
    {
        public static void Log(string message) 
        {
            File.AppendAllText(
                $"Files/Logs/log_{DateTime.Now.ToString("yyyy_MM_dd")}.txt", 
                message
            );
        }
    }
}
