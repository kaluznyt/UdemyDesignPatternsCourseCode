using System;

namespace UdemyDesignPatternsCourse.DesignPatterns.Structural.Decorator
{
    public class Lizard : ILizard
    {
        public int Weight { get; set; }

        public void Crawl()
        {
            Console.WriteLine($"Crawling in the dirt with weight {Weight}");
        }
    }
}