using System;


namespace ArdalisRating.Logging
{
    public class ConsoleLogger : ILogger
    {
        public void WriteMessage(string message)
        {
            Console.WriteLine(message);
        }
    }
}
