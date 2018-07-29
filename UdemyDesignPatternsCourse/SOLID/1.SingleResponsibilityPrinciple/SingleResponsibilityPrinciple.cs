using System;
using System.IO;

namespace UdemyDesignPatternsCourse.SOLID.SingleResponsibilityPrinciple
{
    public class SingleResponsibilityPrinciple : IDemo
    {
        public void Run()
        {
            var journal = new Journal();
            journal.AddEntry("I cried today");
            journal.AddEntry("I ate a bug");

            Console.WriteLine(journal);

            var persistence = new Persistence();
            var filename = Path.GetTempFileName();

            persistence.SaveToFile(journal, filename);
            Console.WriteLine($"Saved to {filename}");
        }
    }
}
