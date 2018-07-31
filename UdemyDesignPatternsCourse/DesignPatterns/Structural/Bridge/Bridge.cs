using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Autofac;
using Autofac.Core;

namespace UdemyDesignPatternsCourse.DesignPatterns.Structural.Bridge
{
    public interface IRenderer
    {
        void RenderCircle(float radius);
    }

    public class VectorRenderer : IRenderer
    {
        public void RenderCircle(float radius)
        {
            Console.WriteLine($"Drawing a circle of radius {radius}");
        }
    }

    public class RasterRenderer : IRenderer
    {
        public void RenderCircle(float radius)
        {
            Console.WriteLine($"Drawing pixels for circle of radius {radius}");
        }
    }

    public abstract class Shape
    {
        protected IRenderer _renderer;

        public Shape(IRenderer renderer)
        {
            _renderer = renderer;
        }

        public void ChangeRenderer(IRenderer renderer)
        {
            _renderer = renderer;
        }

        public abstract void Render();
        public abstract void Resize(float factor);
    }

    public class Circle : Shape
    {
        private float _radius;

        public Circle(IRenderer renderer, float radius) : base(renderer)
        {
            this._radius = radius;
        }

        public override void Render()
        {
            _renderer.RenderCircle(_radius);
        }

        public override void Resize(float factor)
        {
            _radius *= factor;
        }
    }

    public class Bridge : IDemo
    {
        public void Run()
        {
            IRenderer renderer = new RasterRenderer();
            var circle = new Circle(renderer, 5);
            circle.Render();
            circle.Resize(5);

            circle.ChangeRenderer(new VectorRenderer());
            circle.Render();

            var containerBuilder = new ContainerBuilder();
            containerBuilder.RegisterType<RasterRenderer>().As<IRenderer>().SingleInstance();
            containerBuilder.Register((c, p) => new Circle(c.Resolve<IRenderer>(), p.Positional<float>(0)));

            using (var container = containerBuilder.Build())
            {
                var diCircle = container.Resolve<Circle>(
                    new PositionalParameter(0, 5.0f));

                diCircle.Render();
                diCircle.Resize(5);
                diCircle.Render();
            };
        }
    }
}
