using System;
using System.Collections.Generic;

namespace UdemyDesignPatternsCourse.DesignPatterns.Factories
{
    public class HotDrinkMachineThatBreaksOpenClosedPrinciple
    {
        public enum AvailableDrink
        {
            Coffee, Tea
        }

        private Dictionary<AvailableDrink, IHotDrinkFactory> factories = new Dictionary<AvailableDrink, IHotDrinkFactory>();

        public HotDrinkMachineThatBreaksOpenClosedPrinciple()
        {
            foreach (AvailableDrink drink in Enum.GetValues(typeof(AvailableDrink)))
            {
                var factory = (IHotDrinkFactory)Activator.CreateInstance(
                    Type.GetType(
                        $"UdemyDesignPatternsCourse.DesignPatterns.Factories.{Enum.GetName(typeof(AvailableDrink), drink)}Factory"));

                factories.Add(drink, factory);
            }
        }

        public IHotDrink MakeDrink(AvailableDrink drink, int amount)
        {
            return factories[drink].Prepare(amount);
        }
    }
}