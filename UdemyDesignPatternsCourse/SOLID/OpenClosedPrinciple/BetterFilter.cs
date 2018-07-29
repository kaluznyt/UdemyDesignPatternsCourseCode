using System.Collections.Generic;

namespace UdemyDesignPatternsCourse.SOLID.OpenClosedPrinciple
{
    class BetterFilter : IFilter<Product>
    {
        public IEnumerable<Product> Filter(IEnumerable<Product> items, ISpecification<Product> specification)
        {
            foreach (var product in items)
            {
                if (specification.IsSatisfied(product))
                {
                    yield return product;
                }
            }
        }
    }
}