namespace UdemyDesignPatternsCourse.DesignPatterns.Structural.Bridge
{
    namespace Exercise
    {
        public abstract class Shape
        {
            private readonly IRenderer _renderer;

            public Shape(IRenderer renderer)
            {
                _renderer = renderer;
            }

            public string Name { get; set; }

            public override string ToString()
            {
                return $"Drawing {Name} as {_renderer.WhatToRenderAs}";
            }
        }

        public class Triangle : Shape
        {
            public Triangle(IRenderer renderer) : base(renderer)
            {
                Name = "Triangle";
            }
        }

        public class Square : Shape
        {
            public Square(IRenderer renderer) : base(renderer)
            {
                Name = "Square";
            }
        }

        public interface IRenderer
        {
            string WhatToRenderAs { get; }
        }

        public class VectorRenderer : IRenderer
        {
            public string WhatToRenderAs { get; } = "lines";
        }

        public class RasterRenderer : IRenderer
        {
            public string WhatToRenderAs { get; } = "pixels";
        }

        //public class VectorSquare : Square
        //{
        //    public override string ToString() => "Drawing {Name} as lines";
        //}

        //public class RasterSquare : Square
        //{
        //    public override string ToString() => "Drawing {Name} as pixels";
        //}
    }

}
