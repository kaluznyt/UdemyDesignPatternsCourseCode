using System;

namespace UdemyDesignPatternsCourse.DesignPatterns.Factories
{
    internal class TeaFactory : IHotDrinkFactory
    {
        public IHotDrink Prepare(int amount)
        {
            Console.WriteLine($"Put in a teabag, boil water pour {amount} ml, add lemon, enjoy!");
            return new Tea();
        }
    }
}