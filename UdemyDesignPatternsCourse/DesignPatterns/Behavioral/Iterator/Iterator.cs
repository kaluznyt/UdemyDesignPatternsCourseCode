using System;
using System.Text;
using System.Threading.Tasks;

namespace UdemyDesignPatternsCourse.DesignPatterns.Structural.Iterator
{
    public class Iterator : IDemo
    {
        public void Run()
        {
            var root =
                new Node<string>("A",
                    new Node<string>("B",
                        new Node<string>("C",
                            new Node<string>("D"),
                            new Node<string>("E")),
                        new Node<string>("F",
                            new Node<string>("G", null, new Node<string>("Z")),
                            null)),
                    new Node<string>("H",
                        new Node<string>("I"),
                        new Node<string>("J")));

            var it = new InOrderIterator<string>(root);

            while (it.MoveNext())
            {
                Console.WriteLine(it.Current);
            }


            var broot = new BinaryTree<string>(root);

            foreach (var node in broot.InOrder)
            {
                Console.WriteLine(node);
            }

            foreach (var node in broot)
            {
                Console.WriteLine(node);
            }
        }
    }
}
