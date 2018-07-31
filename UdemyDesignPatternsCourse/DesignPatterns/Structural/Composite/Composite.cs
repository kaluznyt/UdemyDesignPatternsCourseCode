using System.Linq;
using System.Threading.Tasks;
using static System.Console;

namespace UdemyDesignPatternsCourse.DesignPatterns.Structural.Composite
{
    public class Composite : IDemo
    {
        public void Run()
        {
            Example1();
            Example2();
        }

        private static void Example1()
        {
            var drawing = new GraphicObject
            {
                Name = "My Drawing"
            };

            drawing.Children.Add(new Square { Color = "Red" });
            drawing.Children.Add(new Circle { Color = "Yellow" });

            var group = new GraphicObject();
            group.Children.Add(new Circle { Color = "Blue" });
            group.Children.Add(new Square { Color = "Blue" });
            drawing.Children.Add(group);

            WriteLine(drawing);
        }

        private static void Example2()
        {
            var neuron1 = new Neuron();
            var neuron2 = new Neuron();

            neuron1.ConnectTo(neuron2);

            var layer1 = new NeuronLayer();
            var layer2 = new NeuronLayer();

            neuron1.ConnectTo(layer1);
            layer1.ConnectTo(layer2);
        }
    }
}
