using System;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Console;

namespace UdemyDesignPatternsCourse.DesignPatterns.Factories
{
    public class Factories : IDemo
    {
        public void Run()
        {
            var point = Point.Factory.NewPolarPoint(1.0, Math.PI / 2);
            WriteLine(point);

            //var hotDrinkMachine = new HotDrinkMachineThatBreaksOpenClosedPrinciple();
            var hotDrinkMachine = new HotDrinkMachine();
            var coffee = hotDrinkMachine.MakeDrink();
            coffee.Consume();
        }
    }

    namespace UdemyDesignPatternsCourse.DesignPatterns.Factories.Problem
    {
        public class Point
        {
            private double x, y;

            public Point(double a, double b, CoordinateSystem system = CoordinateSystem.Cartesian)
            {
                switch (system)
                {
                    case CoordinateSystem.Cartesian:
                        x = a;
                        y = b;
                        break;
                    case CoordinateSystem.Polar:
                        x = a * Math.Cos(b);
                        y = a * Math.Sin(b);
                        break;
                    default:
                        throw new ArgumentOutOfRangeException(nameof(system), system, null);
                }
            }
        }
    }
}
