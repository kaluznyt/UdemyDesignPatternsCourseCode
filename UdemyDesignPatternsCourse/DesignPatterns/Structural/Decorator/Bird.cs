using System;

namespace UdemyDesignPatternsCourse.DesignPatterns.Structural.Decorator
{
    public class Bird : IBird
    {
        public int Weight { get; set; }

        public void Fly()
        {
            Console.WriteLine($"Soaring in the sky with weight {Weight}");
        }
    }
}