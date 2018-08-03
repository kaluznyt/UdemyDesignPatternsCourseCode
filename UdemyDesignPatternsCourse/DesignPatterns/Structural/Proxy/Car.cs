namespace UdemyDesignPatternsCourse.DesignPatterns.Structural.Proxy
{
    using System;

    public class Car : ICar
    {
        public void Drive()
        {
            Console.WriteLine("Car is being driven.");
        }
    }
}