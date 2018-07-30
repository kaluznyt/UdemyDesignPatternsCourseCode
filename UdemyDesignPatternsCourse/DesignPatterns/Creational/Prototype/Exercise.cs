using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UdemyDesignPatternsCourse.DesignPatterns.Creational.Prototype
{
    class Exercise
    {
    }

    public class Point
    {
        public int X, Y;
    }

    public class Line
    {
        public Point Start, End;

        public Line DeepCopy()
        {
            return new Line()
            {
                Start = new Point
                {
                    X = Start.X,
                    Y = Start.Y
                },
                End = new Point
                {
                    X = End.X,
                    Y = End.Y
                }
            };
        }
    }
}
