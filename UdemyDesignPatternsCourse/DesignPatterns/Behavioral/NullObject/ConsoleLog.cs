namespace UdemyDesignPatternsCourse.DesignPatterns.Behavioral.NullObject
{
    using System;

    public class ConsoleLog : ILog
    {
        public void Info(string msg)
        {
            Console.WriteLine($"Info: {msg}");
        }

        public void Warn(string msg)
        {
            Console.WriteLine($"Warning: {msg}");
        }
    }
}