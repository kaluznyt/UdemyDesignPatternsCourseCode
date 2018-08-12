using System;
using System.Numerics;

namespace Coding.Exercise
{
    public interface IDiscriminantStrategy
    {
        double CalculateDiscriminant(double a, double b, double c);
    }

    public class OrdinaryDiscriminantStrategy : IDiscriminantStrategy
    {
        // todo
        public double CalculateDiscriminant(double a, double b, double c)
        {
            var discriminant = Math.Pow(b, 2) - (4 * a * c);
            return discriminant;
        }
    }

    public class RealDiscriminantStrategy : IDiscriminantStrategy
    {
        // todo (return NaN on negative discriminant!)
        public double CalculateDiscriminant(double a, double b, double c)
        {
            var discriminant = Math.Pow(b, 2) - (4 * a * c);

            return discriminant < 0 ? double.NaN : discriminant;
        }
    }

    public class QuadraticEquationSolver
    {
        private readonly IDiscriminantStrategy strategy;

        public QuadraticEquationSolver(IDiscriminantStrategy strategy)
        {
            this.strategy = strategy;
        }

        public Tuple<Complex, Complex> Solve(double a, double b, double c)
        {
            Console.WriteLine($"a: {a} b: {b} c: {c}");

            var discriminant = this.strategy.CalculateDiscriminant(a, b, c);

            if(double.IsNaN(discriminant))
                return new Tuple<Complex, Complex>(new Complex(discriminant, discriminant), new Complex(discriminant, discriminant));

            var plus = (-b + (discriminant < 0 ? 0 : Math.Sqrt(discriminant))) / (2 * a);
            var minus = (-b -(discriminant < 0 ? 0 : Math.Sqrt(discriminant))) / (2 * a);

            discriminant = discriminant < 0 ? 1 : 0;

            return new Tuple<Complex, Complex>(new Complex(plus, discriminant), new Complex(minus, -discriminant));
        }
    }
}