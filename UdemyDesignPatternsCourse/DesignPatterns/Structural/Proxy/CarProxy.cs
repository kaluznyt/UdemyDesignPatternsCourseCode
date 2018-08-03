namespace UdemyDesignPatternsCourse.DesignPatterns.Structural.Proxy
{
    using System;

    public class CarProxy : ICar
    {
        private readonly Driver driver;
        private readonly ICar car;

        public CarProxy(Driver driver, ICar car)
        {
            this.driver = driver;
            this.car = car;
        }

        public void Drive()
        {
            if (this.driver.Age >= 16)
            {
                this.car.Drive();
            }
            else
            {
                Console.WriteLine("Too young to drive");
            }
        }
    }
}