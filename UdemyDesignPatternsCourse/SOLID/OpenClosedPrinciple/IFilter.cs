using System.Collections.Generic;

namespace UdemyDesignPatternsCourse.SOLID.OpenClosedPrinciple
{
    interface IFilter<T>
    {
        IEnumerable<T> Filter(IEnumerable<T> items, ISpecification<T> specification);
    }
}