using System;

namespace UdemyDesignPatternsCourse.SOLID.OpenClosedPrinciple
{
    public class OpenClosedPrinciple : IDemo
    {
        public void Run()
        {
            var apple = new Product("Apple", Color.Green, Size.Small);
            var tree = new Product("Tree", Color.Green, Size.Large);
            var house = new Product("House", Color.Blue, Size.Large);
            var truck = new Product("Truck", Color.Blue, Size.Large);

            Product[] products = { apple, tree, house, truck };

            var filter = new ProductFilter();

            Console.WriteLine("Green products (old):");

            foreach (var greenProduct in filter.FilterByColor(products, Color.Green))
            {
                Console.WriteLine($"- {greenProduct.Name} is green");
            }

            Console.WriteLine("Green products (new):");

            foreach (var greenProduct in new BetterFilter()
                                               .Filter(products,
                                                    new ColorSpecification(Color.Green)))
            {
                Console.WriteLine($"- {greenProduct.Name} is green");
            }

            Console.WriteLine("Large products (new):");

            foreach (var greenProduct in new BetterFilter()
                .Filter(products,
                    new SizeSpecification(Size.Large)))
            {
                Console.WriteLine($"- {greenProduct.Name} is large");
            }

            Console.WriteLine("Large blue products (new):");

            foreach (var greenProduct in new BetterFilter()
                .Filter(products,
                    new AndSpecification<Product>(
                            new SizeSpecification(Size.Large), 
                            new ColorSpecification(Color.Blue))))
            {
                Console.WriteLine($"- {greenProduct.Name} is large and blue");
            }
        }
    }
}
