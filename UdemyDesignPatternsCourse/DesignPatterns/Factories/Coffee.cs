using System;

namespace UdemyDesignPatternsCourse.DesignPatterns.Factories
{
    internal class Coffee : IHotDrink
    {
        public void Consume()
        {
            Console.WriteLine("This coffe is sensational!");
        }
    }
}