using System;

namespace UdemyDesignPatternsCourse.DesignPatterns.Factories
{
    internal class CoffeeFactory : IHotDrinkFactory
    {
        public IHotDrink Prepare(int amount)
        {
            Console.WriteLine($"Grind beans, boild water, pour {amount} ml, add milk, enjoy!");
            return new Coffee();
        }
    }
}