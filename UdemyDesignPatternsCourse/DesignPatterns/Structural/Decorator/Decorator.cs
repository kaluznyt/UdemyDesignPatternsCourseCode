using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using static System.Console;

namespace UdemyDesignPatternsCourse.DesignPatterns.Structural.Decorator
{


    public class Decorator : IDemo
    {
        public void Run()
        {
            //CodeBuilder.Demo();
            //MyStringBuilder.Demo();
            //Dragon.Demo();
            //ShapesDecoratorDemo();
            var redSquare = new ColoredShape<SquareImp>();

            WriteLine(redSquare.AsString());

            var transparentShape = new TransparentShape<ColoredShape<SquareImp>>(1);

            WriteLine(transparentShape.AsString());

        }

        private static void ShapesDecoratorDemo()
        {
            var square = new Square(1.24f);
            WriteLine(square.AsString);

            var redSquare = new ColoredShape(square, "Red");
            WriteLine(redSquare.AsString);

            var transparentRedSquare = new TransparentShape(redSquare, 1.2f);
            WriteLine(transparentRedSquare.AsString);

        }
    }

    public abstract class AbstractShape
    {
        public abstract string AsString();
    }

    public class SquareImp : AbstractShape
    {
        private float side;

        public SquareImp() : this(0)
        {

        }

        public SquareImp(float side)
        {
            this.side = side;
        }

        public override string AsString() => $"A square with side {side}";
    }

    public class ColoredShapeImpl : AbstractShape
    {
        private AbstractShape shape;
        private string color;

        public ColoredShapeImpl(AbstractShape shape, string color)
        {
            this.shape = shape;
            this.color = color;
        }

        public override string AsString() => $"{shape.AsString()} has the color {color}";
    }



    public class TransparentShapeImpl : AbstractShape
    {
        private AbstractShape shape;
        private float transparency;

        public TransparentShapeImpl(AbstractShape shape, float transparency)
        {
            this.shape = shape;
            this.transparency = transparency;
        }

        public override string AsString() => $"{shape.AsString()} has {transparency * 100.0}%";
    }

    public class ColoredShape<T> : AbstractShape where T : AbstractShape, new()
    {
        private readonly string color;
        private readonly T shape = new T();

        public ColoredShape() : this("black")
        {

        }

        public ColoredShape(string color)
        {
            this.color = color;
        }

        public override string AsString()
        {
            return $"{shape.AsString()} has the color {color}";
        }
    }

    public class TransparentShape<T> : AbstractShape where T : AbstractShape, new()
    {
        private readonly float transparency;
        private readonly T shape = new T();

        public TransparentShape() : this(1)
        {

        }

        public TransparentShape(float transparency)
        {
            this.transparency = transparency;
        }

        public override string AsString()
        {
            return $"{shape.AsString()} has the transparency {transparency}";
        }
    }
}
